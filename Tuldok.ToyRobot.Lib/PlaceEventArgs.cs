using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuldok.ToyRobot.Lib
{
    public class PlaceEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
