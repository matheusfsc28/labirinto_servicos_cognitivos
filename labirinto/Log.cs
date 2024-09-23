using System.Diagnostics;
using System.IO;
using System.Text;

namespace labirinto
{
    public class Log
    {
        private string _mazeName;
        public string _filePath;
        private string _logDirectory;

        public Log(string mazeName)
        {
            _mazeName = mazeName;

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(projectDirectory, "..", "..", "..", "LogCSV");

            logDirectory = Path.GetFullPath(logDirectory);

            _logDirectory = logDirectory;

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
                writer.WriteLine("Comando enviado,Leitura do sensor do lado esquerdo do rob� ap�s execu��o do comando,Leitura do sensor do lado direito do rob� ap�s execu��o do comando,Leitura do sensor frontal do rob� ap�s execu��o do comando,Situa��o do compartimento de carga");
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

        public void WriteFilePath()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Confira o arquivo log em:\n");
            Console.WriteLine(_filePath);
            Console.WriteLine("\n");
        }

        public void OpenLogDirectory()
        {
            if (Directory.Exists(_logDirectory))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _logDirectory,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            else
            {
                Console.WriteLine("O diret�rio de logs n�o foi encontrado.");
            }
        }
    }
}

