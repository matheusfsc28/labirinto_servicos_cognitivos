namespace labirinto
{
    public class Robot
    {
        public int battery;

        public Robot(int _battery = 2) 
        { 
            battery = _battery;
        }

        public void DischargeBattery() 
        {
            battery--;
        }
    }
}
