namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("C:\\Users\\sckgu\\OneDrive\\Documentos\\FACULDADE\\Serviços Cognitivos\\ADS 1\\labirinto_servicos_cognitivos\\labirinto\\labirintos\\10x20semerro.txt");

            Robot robot = new Robot();
            Maze maze = new Maze(data, robot);
            Radar radar = new Radar(maze);

            radar.SearchHuman();
            foreach (var step in radar.pathSaved)
            {
                Console.WriteLine($"Posição: ({step.Item1}, {step.Item2})");
            }
            //maze.writeMaze();


        }
    }
}
