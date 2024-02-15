
namespace Environmental_Modeling
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Environmental Modeling";

            ConsoleOceanViewer.DisplayTemplate();
            
            //Input();

            Ocean myOcean = new Ocean();

            //myOcean.SomethingHappened += ConsoleOceanViewer.Display;
            //myOcean.TimeToDisplayOcean += ConsoleOceanViewer.DisplayOcean;

            ConsoleOceanViewer.DisplayIteration(0);
            ConsoleOceanViewer.DisplayStats(myOcean);

            myOcean.Initialize();

            myOcean.Run();

            Console.ReadKey();
        }


        //private static void Input()
        //{
        //    //            private int _numRows = 20;
        //    //private int _numColumns = 70;
        //    //private int _size;// = _numRows * _numColumns;
        //    //private int _numObstacles = 75;
        //    //private int _numPredators = 20;
        //    //private int _numPrey = 150;
        //    //private Random _random;
        //    //private Cell[,] _cells;

        //    int numObstacles = InputData($"obstacles  (default = 75)");
        //    if (numObstacles <= _size)
        //    {
        //        _numObstacles = numObstacles;
        //        Console.WriteLine($"Number obstacles accepted = {_numObstacles}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Number obstacles default = {_numObstacles}");
        //    }

        //    int numPredators = InputData($"predators (default = {_numPredators})");
        //    if (numPredators <= _size - _numObstacles)
        //    {
        //        _numPredators = numPredators;
        //        Console.WriteLine($"Number predators accepted = {_numPredators}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Number predators default = {_numPredators}");
        //    }

        //    int numPrey = InputData($"prey (default = {_numPrey})");
        //    if (numPrey <= _size - _numObstacles - _numPredators)
        //    {
        //        _numPrey = numPrey;
        //        Console.WriteLine($"Number prey accepted = {_numPrey}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Number prey default = {_numPrey}");
        //    }
        //}

        //private int InputData(string message)
        //{
        //    //put method as static in proper classic - make it virtual

        //    //if tryparse fails dont write "number accepted"
        //    Console.Write($"Enter number of {message}: ");
        //    int.TryParse(Console.ReadLine(), out int value);
        //    return value;
        //}

        #region InitializeMethods

        //public void Run()
        //{
        //    int tempIteration = 0;
        //    for (int iteration = 0; iteration < _numIterations; iteration++)
        //    {
        //        tempIteration = iteration; //remove debug only
        //        if (NumPredators > 0 && NumPrey > 0)
        //        {
        //            #region next turn
        //            for (int row = 0; row < _numRows; row++)
        //            {
        //                for (int column = 0; column < _numColumns; column++)
        //                {
        //                    _cells[row, column].turnReady = true;
        //                    //_cells[row, column].Display();
        //                    //_cells[row, column].DisplayCell;
        //                }
        //            }
        //            #endregion
        //            for (int row = 0; row < _numRows; row++)
        //            {
        //                for (int column = 0; column < _numColumns; column++)
        //                {
        //                    if (_cells[row, column].turnReady)
        //                    {
        //                        //_cells[row, column].Dis
        //                        _cells[row, column].Process();
        //                        if (NumPredators <= 0 || NumPrey <= 0)
        //                        {
        //                            break;
        //                        }
        //                        //DisplayCell.Invoke();
        //                    }
        //                    //Console.ReadKey();
        //                }
        //            }
        //            DisplayIteration(iteration);
        //            DisplayStats();
        //            //DisplayCells();
        //            Console.ReadKey();
        //            //tempIteration = iteration; //remove debug only
        //        }
        //    }

        //    //DisplayStats(tempIteration);
        //    Console.ReadKey();
        //    Console.SetCursorPosition(0, 4 + 1 + _numRows + 1);
        //    Console.WriteLine("End of simulation...\n");
        //}
        #endregion
    }
}
