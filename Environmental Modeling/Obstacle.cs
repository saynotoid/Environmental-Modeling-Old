using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environmental_Modeling_Old
{
    internal class Obstacle : Cell
    {
        #region Constructors
        public Obstacle(Coordinate coord, char image = '#') : base(coord, image)
        {
        }

        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;//.Green;
            Console.SetCursorPosition(Offset.X + 1, Offset.Y + 5);
            Console.Write($"{Image}");
            Console.ResetColor();
        }

        // implement IDisposable
        //~Obstacle()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}