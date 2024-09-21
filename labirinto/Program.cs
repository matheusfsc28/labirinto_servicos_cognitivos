namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("C:\\Users\\sckgu\\OneDrive\\Documentos\\FACULDADE\\Serviços Cognitivos\\ADS 1\\labirinto_servicos_cognitivos\\labirinto\\labirintos\\trivial.txt");

            Maze maze = new Maze(data);
            Robot robot = new Robot(maze);

            robot.RescueHuman();
            foreach (var step in robot.pathSaved)
            {
                Console.WriteLine($"Posição: ({step.Item1}, {step.Item2})");
            }
        }
    }
}
