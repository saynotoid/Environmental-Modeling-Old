using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Environmental_Modeling
{
    internal class Prey : Cell
    {
        #region fields
        protected ushort _timeToReproduce;
        #endregion

        #region Process and Display Methods
        protected void MoveFrom(Coordinate from, Coordinate to)
        {
            throw new NotImplementedException();
        }

        protected virtual Cell Reproduce(Coordinate offset)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructors
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