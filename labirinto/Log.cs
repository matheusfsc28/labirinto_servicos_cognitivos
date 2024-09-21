using System.IO;

namespace labirinto
{
    public class Log
    {
        public void WriteToCsv(char movement, string frontSensor, string rightSensor, string leftSensor)
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "LogCSV", "teste.csv");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{movement},{frontSensor},{rightSensor},{leftSensor}");
            }
        }
    }
}