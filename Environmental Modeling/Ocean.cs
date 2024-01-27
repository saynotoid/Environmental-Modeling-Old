using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environmental_Modeling
{
    internal class Ocean : Biome
    {
        #region fields
        private ushort _numRows;
        private ushort _numColumns;
        private ushort _size;// = _numRows * _numColumns;
        private ushort _numPrey;
        private ushort _numPredators;
        private ushort _numObstacles;
        private Random _random;
        private Cell[,] _cells;
        #endregion

        #region InitializationMethods
        private void InitCells()
        {
            throw new NotImplementedException();
        }
        private void AddEmptyCells()
        {
            throw new NotImplementedException();
        }

        private void AddObstacles()
        {
            throw new NotImplementedException();
        }

        private void AddPredators()
        {
            throw new NotImplementedException();
        }

        private void AddPrey()
        {
            throw new NotImplementedException();
        }

        private Coordinate GetEmptyCellCoord()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Display Methods
        private void DisplayBorder()
        {
            throw new NotImplementedException();
        }

        private void DisplayCells()
        {
            throw new NotImplementedException();
        }

        private void DisplayStats()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Access Methods -> Properties
        public ushort NumPrey
        {
            get { return _numPrey; }
            set { _numPrey = value; }
        }

        public ushort NumPredators
        {
            get {  return _numPredators; }
            set { _numPredators = value; }
        }
        #endregion

        #region InitializeMethods
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
