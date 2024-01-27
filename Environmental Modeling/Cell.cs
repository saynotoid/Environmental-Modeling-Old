using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environmental_Modeling
{
    internal abstract class Cell
    {
        #region fields
        protected static Ocean ocean1;
        protected Coordinate _offset;
        protected char _image;
        #endregion

        #region FindNeighbor Methods
        protected Cell GetCellAt(Coordinate coord)
        {
            throw new NotImplementedException();
        }

        protected void AssignCellAt(Coordinate coord, Cell cell)
        {
            throw new NotImplementedException();
        }

        protected Cell GetNeighborWithImage(char image)
        {
            throw new NotImplementedException();
        }

        protected Coordinate GetEmptyNeighborCoord()
        {
            throw new NotImplementedException();
        }

        protected Coordinate GetPreyNeighborCoord()
        {
            throw new NotImplementedException();
        }

        protected Cell North()
        {
            throw new NotImplementedException();
        }

        protected Cell South()
        {
            throw new NotImplementedException();
        }

        protected Cell East()
        {
            throw new NotImplementedException();
        }

        protected Cell West()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Process and Display Methods
        protected virtual Cell Reproduce(Coordinate offset)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructors
        public Cell(Coordinate coord, char image = '-')
        {
            _offset = coord;
            _image = image; //DefaultImage
        }

        public Cell()
        {
            throw new NotImplementedException();
        }

        // implement IDisposable
        ~Cell()
        {
            throw new NotImplementedException();
        }
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
        public void Display()
        {
            throw new NotImplementedException();
        }

        public virtual void Process()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
