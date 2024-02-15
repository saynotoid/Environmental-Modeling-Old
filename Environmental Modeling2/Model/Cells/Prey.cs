using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Environmental_Modeling
{
    public class Prey(Ocean owner, Coordinate coordinate, char image = Constants.IMAGE_PREY) : Cell(owner, coordinate, image)
    {
        public override event CellChangedEventHandler CellChanged;

        #region Fields
        protected int _timeToReproduce = Constants.TimeToReproduce;
        #endregion

        #region Constructors
        //primary constructor is used
        #endregion

        #region Process Methods
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
                //AssignCellAt(from, new Cell(from));
                if (_timeToReproduce <= 0)
                {
                    _timeToReproduce = Constants.TimeToReproduce;
                    AssignCellAt(from, Reproduce(from));
                }
                else
                {
                    AssignCellAt(from, new Cell(_owner, from));
                }
            }
        }

        protected override Cell Reproduce(Coordinate offset)
        {
            ++_owner.NumPrey;
            Prey prey = new Prey(_owner, Offset);
            CellChanged?.Invoke(prey);
            return prey;
        }


        public override void Process()
        {
            this.turnReady = false;
            Coordinate toCoord;
            toCoord = GetEmptyNeighborCoord();
            MoveFrom(Offset, toCoord);
        }
        #endregion
    }
}