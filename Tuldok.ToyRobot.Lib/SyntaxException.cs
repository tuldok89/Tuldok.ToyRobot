using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuldok.ToyRobot.Lib
{
    public class SyntaxException : Exception
    {
        public SyntaxException(Exception innerException) : base("Command syntax error.", innerException)
        {

        }

        public SyntaxException() : base("Command syntax error.")
        {

        }
    }
}
