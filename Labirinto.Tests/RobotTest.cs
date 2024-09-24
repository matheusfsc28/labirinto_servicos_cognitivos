using System.Text;

namespace labirinto.Tests
{
    public class RobotTest
    {
        [Fact]
        public void DischargeBattery_ShouldDischargeRobot()
        {
            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt, "teste");
            Robot robot = new Robot(maze);

            robot.DischargeBattery();

            Assert.Equal(1, robot.battery);

            robot.DischargeBattery();

            Assert.Equal(0, robot.battery);
        }

        [Fact]
        public void SetOrientation_ShouldReturnNorthOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "10x10normal.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data, " ");
            Robot robot = new Robot(maze);

            Assert.Equal("north", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnEastOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "10x20semerro.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data, " ");
            Robot robot = new Robot(maze);

            Assert.Equal("east", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnSouthOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "trivial.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data, "");
            Robot robot = new Robot(maze);

            Assert.Equal("south", robot.compass);
        }

        [Fact]
        public void SetOrientation_ShouldReturnWestOrientation()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", "labirintos", "7x7west.txt");
            var data = File.ReadAllText(filePath);

            Maze maze = new Maze(data, "");
            Robot robot = new Robot(maze);

            Assert.Equal("west", robot.compass);
        }

        [Fact]
        public void CheckSensorsAround_ShouldReturnCorrectPositions()
        {
            int currentRow = 2;
            int currentColumn = 2;
            (int, int) movementDirectionsFront = (0, 1);
            (int, int) movementDirectionsRight = (1, 0);
            (int, int) movementDirectionsLeft = (-1, 0);

            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt, " ");

            Robot robot = new Robot(maze);

            var result = robot.CheckSensorsAround(currentRow, currentColumn,
                movementDirectionsFront, movementDirectionsRight, movementDirectionsLeft);

            var expectedFront = (2, 3);
            var expectedRight = (3, 2);
            var expectedLeft = (1, 2);

            Assert.Equal(expectedFront, result.Item1);
            Assert.Equal(expectedRight, result.Item2);
            Assert.Equal(expectedLeft, result.Item3);
        }

        [Fact]
        public void CheckFrontSensor_ShouldReturnTrue_WhenLocalizationMatchesMovement()
        {
            (int, int) localization = (2, 2);
            (int, int) movement = (2, 2);

            string mazeTxt = "****\n*E *\n****";

            Maze maze = new Maze(mazeTxt, "teste1");
            Robot robot = new Robot(maze);

            bool result = robot.CheckFrontSensor(localization, movement);

            Assert.True(result);
        }

        [Fact]
        public void CheckFrontSensor_ShouldReturnFalse_WhenLocalizationDoesNotMatchMovement()
        {
            (int, int) localization = (2, 2);
            (int, int) movement = (3, 2);

            string mazeTxt = "****\n*E *\n****";

            Maze maze = new Maze(mazeTxt, " ");
            Robot robot = new Robot(maze);
            bool result = robot.CheckFrontSensor(localization, movement);

            Assert.False(result);
        }

        [Fact]
        public void MoveTo_ShouldMoveRobotCorrectly()
        {
            int currentRow = 2;
            int currentColumn = 2;
            (int, int) localization = (3, 2);

            string mazeTxt = "****\n*E *\n****";
            Maze maze = new Maze(mazeTxt, " ");

            Robot robot = new Robot(maze);
            robot.compass = "north";

            var result = robot.MoveTo(currentRow, currentColumn, localization);

            Assert.Equal(localization, result);
        }
    }
}