using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Environmental_Modeling
{
    internal struct Coordinate: IComparable<Coordinate>, IEquatable<Coordinate>
    {
        #region fields
        private int _x;
        private int _y;
        #endregion

        #region Constructors
        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coordinate()
        {
            _x = 0;
            _y = 0;
        }

        public Coordinate(Coordinate coord)
        {
            _x = coord.X;
            _y = coord.Y;
        }

        // implement IDisposable
        //~Coordinate()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Access Methods -> Properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        #endregion

        #region Operators overload
        public static bool operator ==(Coordinate coord1, Coordinate coord2)
        {
            return (coord1.X == coord2.X && coord1.Y == coord2.Y);
        }

        public static bool operator !=(Coordinate coord1, Coordinate coord2)
        {
            return !(coord1 == coord2);
        }

        public override bool Equals(object obj)
        {
            //think about it - maybe make manual
            return obj is Coordinate && Equals((Coordinate)obj);
        }

        public bool Equals(Coordinate coord)
        {
            //if (coord == null)
            //    return false;

            return  X == coord.X && Y == coord.Y;
        }

        public int CompareTo(Coordinate other)
        {
            return this.CompareTo(other);
        }

        public override int GetHashCode()
        {

            return base.GetHashCode();
        }
        #endregion
    }
}