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

    }
}