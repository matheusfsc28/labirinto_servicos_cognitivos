using System.Text;

namespace labirinto.Tests
{
    public class MazeTest
    {
        [Fact]
        public void SetArrayMaze_ShouldCorrectlyConfigureArrayMaze()
        {
            string mazeTxt = "####\n#E #\n####";
            Robot robot = new Robot(); // Supondo que você tenha uma classe Robot
            Maze maze = new Maze(mazeTxt, robot);

            char[,] expectedArrayMaze = new char[,]
            {
            { '#', '#', '#', '#' },
            { '#', 'E', ' ', '#' },
            { '#', '#', '#', '#' }
            };

            Assert.NotNull(maze.arrayMaze);
            Assert.Equal(3, maze.linesLength);
            Assert.Equal(4, maze.columnLength);
            Assert.Equal(1, maze.entranceRow);
            Assert.Equal(1, maze.entranceColumn);
        }

    }
}