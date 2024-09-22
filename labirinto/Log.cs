using System.IO;
using System.Text;

namespace labirinto
{
    public class Log
    {
        private string _mazeName;
        private string _filePath;

        public Log(string mazeName)
        {
            _mazeName = mazeName;

            string projectDirectory = Directory.GetCurrentDirectory();
            string logDirectory = Path.Combine(projectDirectory, "..", "..", "..", "LogCSV");
            _filePath = Path.Combine(logDirectory, $"{_mazeName}.csv");

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (StreamWriter writer = new StreamWriter(_filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Comando enviado,Leitura do sensor do lado esquerdo do robô após execução do comando,Leitura do sensor do lado direito do robô após execução do comando,Leitura do sensor do lado direito do robô após execução do comando,Situação do compartimento de carga");
            }
        }

        public void WriteToCsv(string movement, string frontSensor, string rightSensor, string leftSensor, bool hasHuman)
        {
            string hasHumanText = hasHuman ? "COM HUMANO" : "SEM CARGA";

            using (StreamWriter writer = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                writer.WriteLine($"{movement},{leftSensor},{rightSensor},{frontSensor},{hasHumanText}");
            }
        }
    }
}
