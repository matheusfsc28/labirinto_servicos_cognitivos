using System.Text;

namespace labirinto.Tests
{
    public class RobotTest
    {
        [Fact]
        public void DischargeBattery_ShouldDischargeRobot()
        {
            Robot robot = new Robot();

            robot.DischargeBattery();

            Assert.Equal(1, robot.battery);
        }

    }
}