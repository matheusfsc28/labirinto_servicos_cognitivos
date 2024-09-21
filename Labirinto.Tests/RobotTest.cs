using System.Text;

namespace labirinto.Tests
{
    public class RobotTest
    {
        [Fact]
        public void DischargeBattery_ShouldDischargeRobot()
        {
            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt);
            Robot robot = new Robot(maze);

            robot.DischargeBattery();

            Assert.Equal(1, robot.battery);

            robot.DischargeBattery();

            Assert.Equal(0, robot.battery);
        }

        [Fact]
        public void Sensor_ShouldReturnTrue()
        {
            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt);
            Robot robot = new Robot(maze);

            Assert.True(robot.Sensor((1, 1), (1, 1)));
        }

        [Fact]
        public void Sensor_ShouldReturnFalse()
        {
            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt);
            Robot robot = new Robot(maze);

            Assert.False(robot.Sensor((1, 1), (1, 2)));
        }

        [Fact]
        public void SetOrientation_ShouldReturnNorthOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "10x10normal.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data);
            Robot robot = new Robot(maze);

            Assert.Equal("north", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnEastOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "10x20semerro.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data);
            Robot robot = new Robot(maze);

            Assert.Equal("east", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnSouthOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "trivial.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data);
            Robot robot = new Robot(maze);

            Assert.Equal("south", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnWestOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "7x7.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data);
            Robot robot = new Robot(maze);

            Assert.Equal("west", robot.compass);
        }
    }
}