using System.IO;

namespace labirinto
{
    public class Log
    {
        public void WriteToCsv(string movement, string frontSensor, string rightSensor, string leftSensor, bool hasHuman)
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "LogCSV", "teste.csv");

            string hasHumanText = hasHuman ? "COM HUMANO" : "SEM CARGA"; 

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{movement},{leftSensor},{rightSensor},{frontSensor},{hasHumanText}");
            }
        }
    }
}