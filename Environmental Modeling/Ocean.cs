using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Environmental_Modeling.Program;

namespace Environmental_Modeling
{
    internal class Ocean : Biome
    {
        //Iвенти в Сell'ах - гарна iдея,
        //але правильнiше - в Ocean: бо там з'являеться можливiсть зробити
        //декiлька iвентiв одночасно:
        //клiтинка звiльнилась в старiй позицii
        //з'явилась в новiй позицii i т.i.

        

        public void UpdateStats()
        {
            Console.WriteLine($"Parent notified: Mark = ");
        }

        //update git


        private int _numIterations = 1000;

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
        public int NumPrey 
        {
            get { return _numPrey; }
            set 
            { 
                _numPrey = value;
                DisplayStats();
            }
        }
        public int NumPredators
        {
            get { return _numPredators; }
            set
            {
                _numPredators = value;
                DisplayStats();
            }
        }

        public Random Random { get { return _random; } private set { _random = value; } }
        public Cell[,] Cells { get { return _cells; } private set { _cells = value; } }
        #endregion

        #region InitializeMethods
        public void Initialize()
        {
            _random = new Random();
            _size = _numRows * _numColumns;

            InitCells();

            Console.Write("Enter number of iterations (default max = 1000): ");
            int.TryParse(Console.ReadLine(), out _numIterations);
            if (_numIterations > 1000)
            {
                _numIterations = 1000;
            }
            Console.WriteLine($"Number iterations = {_numIterations}");
            Console.WriteLine("\npress anykey to begin run...\n");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;
            //Next 3 methods here or in InitCells() like used to??
            DisplayTemplate();
            DisplayIteration(0);
            DisplayStats();
            DisplayBorder();
            DisplayCells();
        }

        public void Run()
        {
            int tempIteration = 0;
            for (int iteration = 0; iteration < _numIterations; iteration++)
            {
                tempIteration = iteration; //remove debug only
                if (NumPredators > 0 && NumPrey > 0)
                {
                    #region next turn
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int column = 0; column < _numColumns; column++)
                        {
                            _cells[row, column].turnReady = true;
                            //_cells[row, column].Display();
                            //_cells[row, column].DisplayCell;
                        }
                    }
                    #endregion
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int column = 0; column < _numColumns; column++)
                        {
                            if (_cells[row, column].turnReady)
                            {
                                //_cells[row, column].Dis
                                _cells[row, column].Process();
                                if (NumPredators <= 0 || NumPrey <= 0)
                                {
                                    break;
                                }
                                //DisplayCell.Invoke();
                            }
                        }
                    }
                    DisplayIteration(iteration);
                    DisplayStats();
                    //DisplayCells();
                    Console.ReadKey();
                    //tempIteration = iteration; //remove debug only
                }
            }

            //DisplayStats(tempIteration);
            Console.ReadKey();
            Console.SetCursorPosition(0, 4 + 1 + _numRows + 1);
            Console.WriteLine("End of simulation...\n");
        }
        #endregion

        #region InitializationMethods
        private void InitCells()
        {
            //Console.SetCursorPosition(0, 0);
            Input();

            AddEmptyCells();
            AddObstacles();
            AddPredators();
            AddPrey();

            Cell.ocean1 = this;
        }

        private void Input()
        {
            int numObstacles = InputData($"obstacles  (default = {_numObstacles})");
            if (numObstacles <= _size)
            {
                _numObstacles = numObstacles;
                Console.WriteLine($"Number obstacles accepted = {_numObstacles}");
            }
            else
            {
                Console.WriteLine($"Number obstacles default = {_numObstacles}");
            }

            int numPredators = InputData($"predators (default = {_numPredators})");
            if (numPredators <= _size - _numObstacles)
            {
                _numPredators = numPredators;
                Console.WriteLine($"Number predators accepted = {_numPredators}");
            }
            else
            {
                Console.WriteLine($"Number predators default = {_numPredators}");
            }

            int numPrey = InputData($"prey (default = {_numPrey})");
            if (numPrey <= _size - _numObstacles - _numPredators)
            {
                _numPrey = numPrey;
                Console.WriteLine($"Number prey accepted = {_numPrey}");
            }
            else
            {
                Console.WriteLine($"Number prey default = {_numPrey}");
            }
        }

        private int InputData(string message)
        {
            //put method as static in proper classic - make it virtual

            //if tryparse fails dont write "number accepted"
            Console.Write($"Enter number of {message}: ");
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }

        private void AddEmptyCells()
        {
            _cells = new Cell[_numRows, _numColumns];
            for (int row = 0; row < _numRows; row++)
            {
                for (int column = 0; column < _numColumns; column++)
                {
                    _cells[row, column] = new Cell(new Coordinate(column, row));
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
                _cells[empty.Y, empty.X] = new Obstacle(empty);
            }
        }

        private void AddPredators()
        {
            Coordinate empty;
            for (int i = 0; i < _numPredators; i++)
            {
                empty = GetEmptyCellCoord();
                _cells[empty.Y, empty.X] = new Predator(empty);
            }
        }

        private void AddPrey()
        {
            Coordinate empty;
            for (int i = 0; i < _numPrey; i++)
            {
                empty = GetEmptyCellCoord();
                _cells[empty.Y, empty.X] = new Prey(empty);
            }
        }

        private Coordinate GetEmptyCellCoord()
        {
            int x; //col
            int y; //row

            do
            {
                x = _random.Next(_numColumns);// - 1);
                y = _random.Next(_numRows);// - 1);
            }
            while (_cells[y, x].Image != Cell.DEFAULT_IMAGE);

            return _cells[y, x].Offset;
        }
        #endregion

        #region Display Methods
        private void DisplayBorder()
        {
            Console.SetCursorPosition(0, 4);
            Console.Write("\u2554"); //double lined border left top angle
            Console.SetCursorPosition(1, 4);
            for (int column = 0; column < _numColumns; column++)
            {
                Console.Write("\u2550"); //double lined border horizontal

            }
            Console.Write("\u2557"); //double lined border right top angle
            for (int row = 0; row < _numRows; row++)
            {
                Console.SetCursorPosition(0, 4+1+row);
                Console.Write("\u2551"); //double lined border vertical
            }
            Console.SetCursorPosition(0, 4 + 1 + _numRows);
            Console.Write("\u255A"); //double lined border left bottom angle
            for (int column = 0; column < _numColumns; column++)
            {
                Console.Write("\u2550"); //double lined border horizontal
            }
            Console.Write("\u255D"); //double lined border right bottom angle
            for (int row = 0; row < _numRows; row++)
            {
                Console.SetCursorPosition(_numColumns + 1, 4 + 1 + row);
                Console.Write("\u2551"); //double lined border vertical
            }
        }

        private void DisplayCells()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int column = 0; column < _numColumns; column++)
                {
                    // column row or row column???
                    _cells[row, column].Display();
                }
                Console.WriteLine();
            }
        }
        private void DisplayIteration(int iteration)
        {
            Console.SetCursorPosition($"Iteration number: ".Length, 0);
            Console.Write($"{iteration}");
        }

        private void DisplayStats()// int iteration)
        {
            //Console.SetCursorPosition($"Iteration number: ".Length, 0);
            //Console.Write($"{iteration}");
            Console.SetCursorPosition($"Obstacles: ".Length, 1);
            Console.WriteLine($"{_numObstacles}");
            Console.SetCursorPosition($"Predators: ".Length, 2);
            Console.WriteLine($"{_numPredators}");
            Console.SetCursorPosition($"Prey: ".Length, 3);
            Console.WriteLine($"{_numPrey}");
        }

        private void DisplayTemplate()
        {
            Console.WriteLine($"Iteration number: ");
            Console.WriteLine($"Obstacles: ");
            Console.WriteLine($"Predators: ");
            Console.WriteLine($"Prey: ");
        }
        #endregion
    }
}
