namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("C:\\Users\\Matheus\\Downloads\\testes básicos\\10x20semerro.txt");

            Robot robot = new Robot();
            Maze maze = new Maze(data, robot);

            maze.writeMaze();


        }
    }
}
