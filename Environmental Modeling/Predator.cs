using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Environmental_Modeling
{
    internal class Predator : Prey
    {
        #region fields
        //private static readonly int TimeToFeed = 6;
        private const int TimeToFeed = 6;
        protected int _timeToFeed;
        #endregion

        #region Process and Display Methods
        protected override Cell Reproduce(Coordinate offset)
        {
            Predator temp = new Predator(offset);
            //what the f? where is +-1?
            ocean1.NumPredators = ocean1.NumPredators + 1;
            return temp;//return(Cell* )temp;
        }
        #endregion

        #region Constructors
        public Predator(Coordinate coord, char image = 'S') : base(coord, image)
        {
            // Remove magic numbers
            _timeToFeed = TimeToFeed;
        }

        // implement IDisposable
        //~Predator()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Process and Display Methods
        public override void Process()
        {
            this.turnReady = false;
            Coordinate toCoord;
            if (--_timeToFeed <= 0)//хищник умирает
            {
                AssignCellAt(Offset, new Cell(Offset));
                //--??
                --ocean1.NumPredators;
                //this.Dispose();
            }
            else// съедает соседнюю добычу (если возможно)
            {
                toCoord = GetPreyNeighborCoord();
                if (toCoord != Offset)
                {
                    --ocean1.NumPrey;
                    _timeToFeed = TimeToFeed;
                    MoveFrom(Offset, toCoord);
                }
                else// перемещается в пустую ячейку (если возможно)
                {
                    base.Process();//Prey.Process();
                }
            }
        }

        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Offset.X + 1, Offset.Y + 5);
            Console.Write($"{Image}");
            Console.ResetColor();
        }
        #endregion
    }
}