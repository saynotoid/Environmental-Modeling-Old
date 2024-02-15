using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Environmental_Modeling
{
    public class Cell(Ocean owner, Coordinate coord, char image = Constants.IMAGE_EMPTY)
    {
        public virtual event CellChangedEventHandler? CellChanged;

        #region Fields
        protected Ocean _owner = owner;
        private Coordinate _offset = coord;
        protected char _image = image;
        public bool turnReady = false;
        #endregion

        #region Properties
        public Coordinate Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        public char Image
        {
            get { return _image; }
            //set { _image = value; }
        }
        #endregion

        #region Constructors
        //primary constructor is used
        #endregion

        #region FindNeighbor Methods
        //make accessors instead???
        protected Cell GetCellAt(Coordinate coord)
        {
            return _owner.Cells[coord.Y, coord.X];
        }

        protected void AssignCellAt(Coordinate coord, Cell cell)
        {
            _owner.Cells[coord.Y, coord.X] = cell;
            CellChanged.Invoke(cell);
        }

        protected Cell GetNeighborWithImage(char image)
        {
            Cell[] neighbors = new Cell[4];
            int count = 0;

            if (North().Image == image)
            {
                neighbors[count++] = North();
            }
            if (South().Image == image)
            {
                neighbors[count++] = South();
            }
            if (East().Image == image)
            {
                neighbors[count++] = East();
            }
            if (West().Image == image)
            {
                neighbors[count++] = West();
            }
            if (count == 0)
            {
                return this;
            }
            else
            {
                return neighbors[_owner.Random.Next(count - 1)];
            }
        }

        protected Coordinate GetEmptyNeighborCoord()
        {
            return GetNeighborWithImage(Constants.IMAGE_EMPTY).Offset;
        }

        protected Coordinate GetPreyNeighborCoord()
        {
            //Magic number
            return GetNeighborWithImage('f').Offset;
        }

        protected Cell North()
        {
            int yValue;

            yValue = Offset.Y > 0 ? Offset.Y - 1 : _owner.NumRows - 1;
            return _owner.Cells[yValue, Offset.X];
        }

        protected Cell South()
        {
            int yValue;

            yValue = (Offset.Y + 1) % _owner.NumRows;
            return _owner.Cells[yValue, Offset.X];
        }

        protected Cell East()
        {
            int xValue;

            xValue = (Offset.X + 1) % _owner.NumColumns;
            return _owner.Cells[Offset.Y, xValue];
        }

        protected Cell West()
        {
            int xValue;

            xValue = Offset.X > 0 ? Offset.X - 1 : _owner.NumColumns - 1;
            return _owner.Cells[Offset.Y, xValue];
        }
        #endregion

        #region Process Methods
        protected virtual Cell Reproduce(Coordinate offset)
        {
            Cell cell = new Cell(_owner, Offset);
            CellChanged?.Invoke(cell);
            return cell;
        }

        public virtual void Process()
        {
            //throw new NotImplementedException();
            this.turnReady = false;
        }
        #endregion
    }
}
