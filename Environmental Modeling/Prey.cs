using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Environmental_Modeling
{
    internal class Prey : Cell
    {
        #region fields
        //private static readonly int TimeToReproduce = 6;
        private const int TimeToReproduce = 6;
        protected int _timeToReproduce;
        #endregion

        #region Process and Display Methods
        protected void MoveFrom(Coordinate from, Coordinate to)
        {
            //Cell toCell;
            --_timeToReproduce;

            if (to != from)
            {
                //toCell = GetCellAt(to);
                //toCell.Dispose();
                Offset = to;
                AssignCellAt(to, this);
                AssignCellAt(from, new Cell(from));
                if (_timeToReproduce <= 0)
                {
                    _timeToReproduce = TimeToReproduce;
                    AssignCellAt(from, Reproduce(from));
                }
                else
                {
                    AssignCellAt(from, new Cell(from));
                }
            }
        }

        protected virtual Cell Reproduce(Coordinate offset)
        {
            Prey temp = new Prey(Offset);
            //What?
            ocean1.NumPrey = ocean1.NumPrey + 1;
            //return (Cell*)temp ???
            return temp;
        }
        #endregion

        #region Constructors
        public Prey(Coordinate coord, char image = 'f') : base(coord, image)
        {
            // Remove magic numbers
            _timeToReproduce = TimeToReproduce;
        }

        // implement IDisposable
        //~Prey()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Process and Display Methods
        public override void Process()
        {
            this.turnReady = false;
            Coordinate toCoord;
            toCoord = GetEmptyNeighborCoord();
            MoveFrom(Offset, toCoord);
        }

        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;//.Blue;
            Console.SetCursorPosition(Offset.X + 1, Offset.Y + 5);
            Console.Write($"{Image}");
            Console.ResetColor();
        }
        #endregion
    }
}