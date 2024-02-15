using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environmental_Modeling
{
    public static class ConsoleOceanViewer
    {
        //цей клас є підписник
        //на події в класі ошеан що є паблішером двох подій

        public static void Display()
        {
            //Console.WriteLine("event 'SomethingHappened' triggered");
        }

        public static void DisplayOcean(Ocean ocean)
        {
            DisplayBorder(ocean);
            Console.SetCursorPosition(1, 5);

            for (int row = 0; row < ocean.NumRows; row++)
            {
                for (int column = 0; column < ocean.NumColumns; column++)
                {
                    DisplayCell(ocean.Cells[row, column]);
                }
                Console.WriteLine();
            }
        }

        //public static void DisplayCell(Ocean ocean, Coordinate offset)
        //{
        //    switch (ocean.Cells[offset.Y, offset.X].Image)
        //    {
        //        case Cell.IMAGE_EMPTY: Console.ForegroundColor = ConsoleColor.White; break;
        //        case Obstacle.IMAGE_OBSTACLE: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
        //        case Prey.IMAGE_PREY: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
        //        case Predator.IMAGE_PREDATOR: Console.ForegroundColor = ConsoleColor.Red; break;
        //        default: Console.ForegroundColor = ConsoleColor.White; break;
        //    }
        //    Console.SetCursorPosition(offset.X + 1, offset.Y + 5);
        //    Console.Write($"{ocean.Cells[offset.Y, offset.X].Image}");
        //    Console.ResetColor();
        //}
        public static void DisplayCell(Cell cell)
        {
            switch (cell.Image)
            {
                case Constants.IMAGE_EMPTY: Console.ForegroundColor = ConsoleColor.White; break;
                case Constants.IMAGE_OBSTACLE: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case Constants.IMAGE_PREY: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case Constants.IMAGE_PREDATOR: Console.ForegroundColor = ConsoleColor.Red; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
            //these magic numbers +1 +5 are offset in console window for lines, showing stats
            Console.SetCursorPosition(cell.Offset.X + 1, cell.Offset.Y + 5);
            Console.Write($"{cell.Image}");
            Console.ResetColor();
        }

        private static void DisplayBorder(Ocean ocean)
        {
            Console.SetCursorPosition(0, 4);
            Console.Write("\u2554"); //double lined border left top angle
            Console.SetCursorPosition(1, 4);
            for (int column = 0; column < ocean.NumColumns; column++)
            {
                Console.Write("\u2550"); //double lined border horizontal

            }
            Console.Write("\u2557"); //double lined border right top angle
            for (int row = 0; row < ocean.NumRows; row++)
            {
                Console.SetCursorPosition(0, 4 + 1 + row);
                Console.Write("\u2551"); //double lined border vertical
            }
            Console.SetCursorPosition(0, 4 + 1 + ocean.NumRows);
            Console.Write("\u255A"); //double lined border left bottom angle
            for (int column = 0; column < ocean.NumColumns; column++)
            {
                Console.Write("\u2550"); //double lined border horizontal
            }
            Console.Write("\u255D"); //double lined border right bottom angle
            for (int row = 0; row < ocean.NumRows; row++)
            {
                Console.SetCursorPosition(ocean.NumColumns + 1, 4 + 1 + row);
                Console.Write("\u2551"); //double lined border vertical
            }
        }

        public static void DisplayIteration(int iteration)
        {
            Console.SetCursorPosition($"Iteration number: ".Length, 0);
            Console.Write($"{iteration}");
        }

        public static void DisplayStats(Ocean ocean)// int iteration)
        {
            //Console.SetCursorPosition($"Iteration number: ".Length, 0);
            //Console.Write($"{iteration}");
            Console.SetCursorPosition($"Obstacles: ".Length, 1);
            Console.WriteLine($"{ocean.NumObstacles}");
            Console.SetCursorPosition($"Predators: ".Length, 2);
            Console.WriteLine($"{ocean.NumPredators}");
            Console.SetCursorPosition($"Prey: ".Length, 3);
            Console.WriteLine($"{ocean.NumPrey}");
        }

        public static void DisplayTemplate()
        {
            Console.WriteLine($"Iteration number: ");
            Console.WriteLine($"Obstacles: ");
            Console.WriteLine($"Predators: ");
            Console.WriteLine($"Prey: ");
        }
    }
}
