using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environmental_Modeling
{
    public class Ocean
    {
        public event OceanCreatedEventHandler OceanCreated;

        private int _numIterations = 1000; //temp variable

        #region Fields
        private int _numRows = 20;
        private int _numColumns = 70;
        private int _size;// = _numRows * _numColumns;
        private int _numObstacles = 75;
        private int _numPredators = 20;
        private int _numPrey = 150;
        private Random _random;
        private Cell[,] _cells;
        #endregion

        #region Properties
        public int NumRows { get { return _numRows; } private set { _numRows = value; } }
        public int NumColumns { get { return _numColumns; } private set { _numColumns = value; } }
        public int NumObstacles { get { return _numObstacles; } set { _numObstacles = value; } }
        public int NumPrey { get { return _numPrey; } set { _numPrey = value; } }
        public int NumPredators { get { return _numPredators; } set { _numPredators = value; } }
        public Random Random { get { return _random; } private set { _random = value; } }
        public Cell[,] Cells { get { return _cells; } private set { _cells = value; } }
        #endregion

        public Ocean(int numRows=20, int numColumns=70, int numObstacles=75, int numPredators=20,int numPrey = 150)
        {
            _numRows = numRows;
            _numColumns = numColumns;
            Cells = new Cell[numRows, numColumns];
            _numObstacles = numObstacles;
            _numPredators = numPredators;
            _numPrey = numPrey;

            _random = new Random();
            _size = _numRows * _numColumns;
        }

        #region InitializationMethods
        public void Initialize()
        {
            AddEmptyCells();
            AddObstacles();
            AddPredators();
            AddPrey();

            for (int row = 0; row < _numRows; row++)
            {
                for (int column = 0; column < _numColumns; column++)
                {
                    _cells[row, column].CellChanged += ConsoleOceanViewer.DisplayCell;
                }
            }

            OceanCreated.Invoke(this);
        }

        private void AddEmptyCells()
        {
            _cells = new Cell[_numRows, _numColumns];
            for (int row = 0; row < _numRows; row++)
            {
                for (int column = 0; column < _numColumns; column++)
                {
                    _cells[row, column] = new Cell(this, new Coordinate(column, row));
                }
            }
        }
        // AddObstacles();AddPredators();AddPrey(); -> AddEntity or AddCellMeaningful generic method or Cell~~.Add()
        private void AddObstacles()
        {
            Coordinate empty;
            for (int i = 0; i < _numObstacles; i++)
            {
                empty = GetEmptyCellCoord();
                _cells[empty.Y, empty.X] = new Obstacle(this, empty);
            }
        }

        private void AddPredators()
        {
            Coordinate empty;
            for (int i = 0; i < _numPredators; i++)
            {
                empty = GetEmptyCellCoord();
                _cells[empty.Y, empty.X] = new Predator(this, empty);
            }
        }

        private void AddPrey()
        {
            Coordinate empty;
            for (int i = 0; i < _numPrey; i++)
            {
                empty = GetEmptyCellCoord();
                _cells[empty.Y, empty.X] = new Prey(this, empty);
            }
        }

        private Coordinate GetEmptyCellCoord()
        {
            int x; //col
            int y; //row

            do
            {
                x = _random.Next(_numColumns);
                y = _random.Next(_numRows);
            }
            while (_cells[y, x].Image != Constants.IMAGE_EMPTY);

            return _cells[y, x].Offset;
        }
        #endregion

        public void Run()
        {
            //int tempIteration = 0;
            for (int iteration = 0; iteration < _numIterations; iteration++)
            {
                //tempIteration = iteration; //remove debug only
                if (NumPredators > 0 && NumPrey > 0)
                {
                    #region next turn
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int column = 0; column < _numColumns; column++)
                        {
                            _cells[row, column].turnReady = true;
                        }
                    }
                    #endregion
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int column = 0; column < _numColumns; column++)
                        {
                            if (_cells[row, column].turnReady)
                            {
                                _cells[row, column].Process();
                                if (NumPredators <= 0 || NumPrey <= 0)
                                {
                                    break;
                                }
                                //DisplayCell.Invoke();
                            }
                            //while (true)
                            //{
                            //    if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                            //        break;
                            //}
                        }
                    }
                    ConsoleOceanViewer.DisplayIteration(iteration);
                    ConsoleOceanViewer.DisplayStats(this);
                    Console.ReadKey();
                    //tempIteration = iteration; //remove debug only
                }
            }

            //DisplayStats(tempIteration);
            Console.ReadKey();
            Console.SetCursorPosition(0, 4 + 1 + _numRows + 1);
            Console.WriteLine("End of simulation...\n");
        }
    }
}
