namespace labirinto
{
    public class Robot : Radar
    {
        public int battery = 2;

        public Robot(Maze maze) : base(maze)
        { 
        }

        public void DischargeBattery() 
        {
            battery--;
        }
    }
}
