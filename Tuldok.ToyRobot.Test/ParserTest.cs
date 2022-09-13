using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuldok.ToyRobot.Lib;

namespace Tuldok.ToyRobot.Test
{
    [TestClass]
    public class ParserTest
    {
        private CommandParser parser;
        private Direction direction;
        private int x;
        private int y;
        private bool moveEvent;
        private bool turnRightEvent;
        private bool turnLeftEvent;
        private bool quitEvent;
        private bool reportEvent;
        private bool placeEvent;

        public ParserTest()
        {
            parser = new CommandParser();
            parser.Move += Parser_Move;
            parser.Place += Parser_Place;
            parser.Quit += Parser_Quit;
            parser.TurnLeft += Parser_TurnLeft;
            parser.TurnRight += Parser_TurnRight;
            parser.Report += Parser_Report;
        }

        private void Parser_Report(object? sender, EventArgs e)
        {
            reportEvent = true;
        }

        private void Parser_TurnRight(object? sender, EventArgs e)
        {
            turnRightEvent = true;
        }

        private void Parser_TurnLeft(object? sender, EventArgs e)
        {
            turnLeftEvent = true;
        }

        private void Parser_Quit(object? sender, EventArgs e)
        {
            quitEvent = true;
        }

        private void Parser_Place(object? sender, PlaceEventArgs e)
        {
            x = e.X;
            y = e.Y;
            direction = e.Direction;
            placeEvent = true;
        }

        private void Parser_Move(object? sender, EventArgs e)
        {
            moveEvent = true;
        }

        private void Clear()
        {
            x = 0;
            y = 0;
            direction = Direction.North;
            moveEvent = false;
            quitEvent = false;
            turnLeftEvent = false;
            turnRightEvent = false;
        }

        [TestMethod]
        public void Place()
        {
            parser.Parse(" PlAcE 1, 1,eAsT ");
            Assert.IsTrue(x == 1 && y == 1 && direction == Direction.East);
            Clear();
        }

        [TestMethod]
        public void Move()
        {
            parser.Parse(" mOvE ");
            Assert.IsTrue(moveEvent);
            Clear();
        }

        [TestMethod]
        public void TurnLeft()
        {
            parser.Parse(" LeFt ");
            Assert.IsTrue(turnLeftEvent);
            Clear();
        }

        [TestMethod]
        public void TurnRight()
        {
            parser.Parse(" RiGhT ");
            Assert.IsTrue(turnRightEvent);
            Clear();
        }

        [TestMethod]
        public void Quit()
        {
            parser.Parse(" qUiT ");
            Assert.IsTrue(quitEvent);
            Clear();
        }

        [TestMethod]
        public void Report()
        {
            parser.Parse(" RePoRt ");
            Assert.IsTrue(reportEvent);
            Clear();
        }

        [TestMethod]
        public void InvalidPlaceDirection()
        {
            Assert.ThrowsException<SyntaxException>(() =>
            {
                parser.Parse("PLACE 4, 5, NORTHX");
            });
        }

        [TestMethod]
        public void InvalidCommand()
        {
            Assert.ThrowsException<SyntaxException>(() =>
            {
                parser.Parse("fdhs sfksfa sadgajdga");
            });
        }
    }
}
