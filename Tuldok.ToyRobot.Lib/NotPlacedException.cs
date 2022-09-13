using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuldok.ToyRobot.Lib
{
    public class NotPlacedException : Exception
    {
        public NotPlacedException() : base("Robot is yet to be placed on the table.")
        {

        }
    }
}
