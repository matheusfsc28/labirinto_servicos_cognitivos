using System.Text;

namespace labirinto.Tests
{
    public class RadarTest
    {
        [Fact]
        public void SearchHuman_ShouldFindHuman_WhenHumanIsPresent()
        {
            string mazeData =
                "*******\n" +
                "*  E  *\n" +
                "* *** *\n" +
                "*     *\n" +
                "***** *\n" +
                "*     *\n" +
                "* ***H*\n" +
                "*******";

            Maze maze = new Maze(mazeData);
            Radar radar = new Radar(maze);

            bool found = radar.SearchHuman();

            Assert.True(found);
        }

        [Fact]
        public void SearchHuman_ShouldReturnFalse_WhenHumanIsNotPresent()
        {
            string mazeData =
                "*******\n" +
                "*  E  *\n" +
                "* *** *\n" +
                "*     *\n" +
                "***** *\n" +
                "*     *\n" +
                "* *** *\n" +
                "*******";

            Maze maze = new Maze(mazeData);
            Radar radar = new Radar(maze);

            bool found = radar.SearchHuman();

            Assert.False(found);
        }

        [Fact]
        public void SearchHuman_ShouldCorrectlyTrackPath()
        {
            string mazeData =
                "*******\n" +
                "*  E  *\n" +
                "* *****\n" +
                "*     *\n" +
                "***** *\n" +
                "*     *\n" +
                "* ***H*\n" +
                "*******";

            Maze maze = new Maze(mazeData);
            Radar radar = new Radar(maze);

            radar.SearchHuman();

            var expectedPath = new List<(int, int)>
            {
                (1, 3), (1, 2), (1, 1), (2, 1), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (4, 5), (5, 5), (6, 5)
            };

            Assert.Equal(expectedPath, radar.pathSaved);
        }
    }
}