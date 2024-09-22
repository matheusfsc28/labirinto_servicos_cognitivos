namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mazeFilePath = "C:\\Users\\mathe\\OneDrive\\Documentos\\code\\studies\\Faculdade\\servicos_cognitivos\\labirinto_servicos_cognitivos\\labirinto\\labirintos\\trivial.txt";
            var data = File.ReadAllText(mazeFilePath);

            string mazeName = Path.GetFileNameWithoutExtension(mazeFilePath);

            Maze maze = new Maze(data, mazeName);
            Robot robot = new Robot(maze);

            robot.RescueHuman();
            foreach (var step in robot.pathSaved)
            {
                Console.WriteLine($"Posição: ({step.Item1}, {step.Item2})");
            }
        }
    }
}
