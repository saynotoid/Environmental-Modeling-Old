using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Environmental_Modeling
{
    public class Predator(Ocean owner, Coordinate coordinate, char image = Constants.IMAGE_PREDATOR) : Prey(owner, coordinate, image)
    {
        public override event CellChangedEventHandler CellChanged;

        #region Fields
        protected int _timeToFeed = Constants.TimeToFeed;
        #endregion

        #region Constructors
        //primary constructor is used
        #endregion

        #region Process Methods
        protected override Cell Reproduce(Coordinate offset)
        {
            ++_owner.NumPredators;
            Predator predator = new Predator(_owner, Offset);
            CellChanged?.Invoke(predator);
            return predator;
        }

        public override void Process()
        {
            this.turnReady = false;
            Coordinate toCoord;
            if (--_timeToFeed <= 0)//хищник умирает
            {
                AssignCellAt(Offset, new Cell(_owner, Offset));
                --_owner.NumPredators;
            }
            else// съедает соседнюю добычу (если возможно)
            {
                toCoord = GetPreyNeighborCoord();
                if (toCoord != Offset)
                {
                    --_owner.NumPrey;
                    _timeToFeed = Constants.TimeToFeed;
                    MoveFrom(Offset, toCoord);
                }
                else// перемещается в пустую ячейку (если возможно)
                {
                    base.Process();//Prey.Process();
                }
            }
        }
        #endregion
    }
}