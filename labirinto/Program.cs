namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mazeFilePath = string.Empty;

            while (true)
            {
                Console.WriteLine("Por favor, insira o caminho completo do arquivo do labirinto (em .txt e no formato LF, conforme passado no exemplo pelo professor):");
                mazeFilePath = Console.ReadLine();

                if (File.Exists(mazeFilePath)) break;
                
                else Console.WriteLine("Arquivo não encontrado. Tente novamente. \n");
            }

            var data = File.ReadAllText(mazeFilePath);

            string mazeName = Path.GetFileNameWithoutExtension(mazeFilePath);

            Maze maze = new Maze(data, mazeName);
            Robot robot = new Robot(maze);

            robot.RescueHuman();
            foreach (var step in robot.pathSaved)
            {
                Console.WriteLine($"Posição: ({step.Item1}, {step.Item2})");
            }

            robot._log.WriteFilePath();
            robot._log.OpenLogDirectory();
        }
    }
}
