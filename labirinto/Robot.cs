using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirinto
{
    internal class Robot
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
