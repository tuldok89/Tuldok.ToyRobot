using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tuldok.ToyRobot.Lib
{

    public class CommandParser
    {
        private Regex _placeRegex;
        const RegexOptions regexOptions = RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.Singleline;

        public CommandParser()
        {
            _placeRegex = new Regex(@"PLACE (?<X>\d+),(\s+)?(?<Y>\d+),(\s+)?(?<Dir>\w+)", regexOptions);
        }

        public event EventHandler? Move;
        public event EventHandler? TurnLeft;
        public event EventHandler? TurnRight;
        public event EventHandler<PlaceEventArgs>? Place;
        public event EventHandler? Quit;
        public event EventHandler? Report;

        public void Parse(string command)
        {
            command = command.Trim();
            var matches = _placeRegex.Matches(command);

            try
            {
                if (matches.Count > 0)
                {
                    var match = matches.First();
                    var x = int.Parse(match.Groups["X"].Value);
                    var y = int.Parse(match.Groups["Y"].Value);
                    var dir = Enum.Parse<Direction>(match.Groups["Dir"].Value, true);

                    var eventArgs = new PlaceEventArgs
                    {
                        Direction = dir,
                        X = x,
                        Y = y
                    };

                    OnPlace(eventArgs);
                }
                else if (string.Compare(command, "MOVE", true) == 0)
                {
                    OnMove();
                }
                else if (string.Compare(command, "LEFT", true) == 0)
                {
                    OnTurnLeft();
                }
                else if (string.Compare(command, "RIGHT", true) == 0)
                {
                    OnTurnRight();
                }
                else if (string.Compare(command, "QUIT", true) == 0)
                {
                    OnQuit();
                }
                else if (string.Compare(command, "REPORT", true) == 0)
                {
                    OnReport();
                }
                else
                {
                    throw new SyntaxException();
                }
            }
            catch (Exception)
            {
                throw new SyntaxException();
            }
        }

        private void OnMove()
        {
            Move?.Invoke(this, EventArgs.Empty);
        }

        private void OnTurnLeft()
        {
            TurnLeft?.Invoke(this, EventArgs.Empty);
        }

        private void OnTurnRight()
        {
            TurnRight?.Invoke(this, EventArgs.Empty);
        }

        private void OnQuit()
        {
            Quit?.Invoke(this, EventArgs.Empty);
        }

        private void OnPlace(PlaceEventArgs placeEventArgs)
        {
            Place?.Invoke(this, placeEventArgs);
        }

        private void OnReport()
        {
            Report?.Invoke(this, EventArgs.Empty);
        }
    }
}
