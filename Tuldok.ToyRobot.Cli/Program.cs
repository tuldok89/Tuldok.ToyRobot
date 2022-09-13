using Tuldok.ToyRobot.Lib;

namespace Tuldok.ToyRobot.Cli
{
    internal class Program
    {
        static Robot _robot = new Robot();

        static void Main(string[] args)
        {
            var parser = new CommandParser();
            parser.Quit += Parser_Quit;
            parser.TurnLeft += Parser_TurnLeft;
            parser.TurnRight += Parser_TurnRight;
            parser.Move += Parser_Move;
            parser.Place += Parser_Place;
            parser.Report += Parser_Report;

            Console.WriteLine("Toy Robot v1.0\n");

            while (true)
            {
                Console.Write("Enter a command: ");
                var cmd = Console.ReadLine();
                try
                {
                    parser.Parse(cmd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void Parser_Report(object? sender, EventArgs e)
        {
            if (_robot.IsPlaced)
                Console.WriteLine($"Robot Position\nX: {_robot.X}\nY: {_robot.Y}\nDirection: {_robot.Direction}\n");
            else
                Console.WriteLine("Robot is yet to be placed on the table.");
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
    }
}