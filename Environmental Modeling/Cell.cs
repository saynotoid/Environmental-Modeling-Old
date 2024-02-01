using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Environmental_Modeling.Program;

namespace Environmental_Modeling
{
    internal class Cell//: IDisposable
    {
        public delegate void DisplayDelegate(Cell sender);

        //public event System.Action<Display> TargetAcquired;


        //public event EventHandler DisplayCell;

        public event DisplayDelegate DisplayCell;

        //DisplayCell += this.Display();

        public bool turnReady = false;

        #region fields
        public const char DEFAULT_IMAGE = '-';
        //make protected -> private via accessors
        //Ocean public???
        public static Ocean ocean1;
        private Coordinate _offset;
        protected char _image;
        #endregion

        ////test indexer via Coord
        //public Cell this[Coordinate coord]
        //{
        //    get { return this[coord.Y,coord.X]; }
        //    set { InnerList[i] = value; }
        //}

        #region FindNeighbor Methods
        //make accessors instead???
        protected Cell GetCellAt(Coordinate coord)
        {
            return ocean1.Cells[coord.Y, coord.X];
        }

        protected void AssignCellAt(Coordinate coord, Cell cell)
        {
            ocean1.Cells[coord.Y, coord.X] = cell;
            cell.Display();
            //DisplayCell.Invoke(this);
            //raise an event
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
                return neighbors[ocean1.Random.Next(count - 1)];
            }
        }

        protected Coordinate GetEmptyNeighborCoord()
        {
            return GetNeighborWithImage(DEFAULT_IMAGE).Offset;
        }

        protected Coordinate GetPreyNeighborCoord()
        {
            //Magic number
            return GetNeighborWithImage('f').Offset;
        }

        protected Cell North()
        {
            int yValue;

            yValue = Offset.Y > 0 ? Offset.Y - 1 : ocean1.NumRows - 1;
            return ocean1.Cells[yValue, Offset.X];
        }

        protected Cell South()
        {
            int yValue;

            //What the hell? is hapenning here %
            yValue = (Offset.Y + 1) % ocean1.NumRows;
            return ocean1.Cells[yValue, Offset.X];
        }

        protected Cell East()
        {
            int xValue;

            //What the hell? is hapenning here %
            xValue = (Offset.X + 1) % ocean1.NumColumns;
            return ocean1.Cells[Offset.Y, xValue];
        }

        protected Cell West()
        {
            int xValue;

            xValue = Offset.X > 0 ? Offset.X - 1 : ocean1.NumColumns - 1;
            return ocean1.Cells[Offset.Y, xValue];
        }
        #endregion

        #region Process and Display Methods
        protected virtual Cell Reproduce(Coordinate offset)
        {
            Cell temp = new Cell(Offset);
            return temp;
        }
        #endregion

        #region Constructors
        public Cell(Coordinate coord, char image = DEFAULT_IMAGE)
        {
            _offset = coord;
            _image = image; //DefaultImage
        }

        public Cell()
        {
            throw new NotImplementedException();
        }

        // implement IDisposable
        //~Cell()
        //{
        //    //throw new NotImplementedException();
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        #endregion

        #region Access Methods -> Properties
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

        #region Process and Display Methods
        public virtual void Display()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Offset.X + 1, Offset.Y + 5);
            Console.Write($"{Image}");
            Console.ResetColor();
        }

        public virtual void Process()
        {
            //throw new NotImplementedException();
            this.turnReady = false;
        }
        #endregion
    }
}
