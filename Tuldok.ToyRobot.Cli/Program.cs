using Tuldok.ToyRobot.Lib;

namespace Tuldok.ToyRobot.Cli
{
    internal class Program
    {
        static Robot _robot = new Robot();
        static List<char> _table = new List<char>();

        static void Main(string[] args)
        {
            var parser = new CommandParser();
            parser.Quit += Parser_Quit;
            parser.TurnLeft += Parser_TurnLeft;
            parser.TurnRight += Parser_TurnRight;
            parser.Move += Parser_Move;
            parser.Place += Parser_Place;
            parser.Report += Parser_Report;

            for(var i = 0; i < 25; i++)
            {
                _table.Add(' ');
            }

            Console.WriteLine("Toy Robot v1.0\n");

            while (true)
            {
                Console.Write("Enter a command: ");
                var cmd = Console.ReadLine();
                try
                {
                    parser.Parse(cmd ?? string.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void Parser_Report(object? sender, EventArgs e)
        {
            Render();
        }

        private static void Parser_Place(object? sender, PlaceEventArgs e)
        {
            try
            {
                _robot.Place(e.X, e.Y, e.Direction);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Parser_Move(object? sender, EventArgs e)
        {
            try
            {
                _robot.Move();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Parser_TurnRight(object? sender, EventArgs e)
        {
            try
            {
                _robot.TurnRight();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Parser_TurnLeft(object? sender, EventArgs e)
        {
            try
            {
                _robot.TurnLeft();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Parser_Quit(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private static void Render()
        {
            char arrow = ' ';

            if (_robot.IsPlaced)
            {
                switch (_robot.Direction)
                {
                    case Direction.North:
                        arrow = '▲';
                        break;
                    case Direction.East:
                        arrow = '►';
                        break;
                    case Direction.South:
                        arrow = '▼';
                        break;
                    case Direction.West:
                        arrow = '◄';
                        break;
                }
            }    

            var x = _robot.X;
            var y = _robot.Y;

            for(int i = 0; i < 25; i++)
            {
                _table[i] = ' ';
            }

            _table[y * 5 + x] = arrow;

            Console.WriteLine("╔═╦═╦═╦═╦═╗");
            Console.WriteLine($"║{_table[20]}║{_table[21]}║{_table[22]}║{_table[23]}║{_table[24]}║");
            Console.WriteLine("╠═╬═╬═╬═╬═╣");
            Console.WriteLine($"║{_table[15]}║{_table[16]}║{_table[17]}║{_table[18]}║{_table[19]}║");
            Console.WriteLine("╠═╬═╬═╬═╬═╣");
            Console.WriteLine($"║{_table[10]}║{_table[11]}║{_table[12]}║{_table[13]}║{_table[14]}║");
            Console.WriteLine("╠═╬═╬═╬═╬═╣");
            Console.WriteLine($"║{_table[5]}║{_table[6]}║{_table[7]}║{_table[8]}║{_table[9]}║");
            Console.WriteLine("╠═╬═╬═╬═╬═╣");
            Console.WriteLine($"║{_table[0]}║{_table[1]}║{_table[2]}║{_table[3]}║{_table[4]}║");
            Console.WriteLine("╚═╩═╩═╩═╩═╝");
        }
    }
}