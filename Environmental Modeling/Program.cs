using System.Diagnostics;
using System.Security.Principal;

namespace Environmental_Modeling_Old
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Environmental Modeling";
            //Console.CursorVisible = false;

            //Console.WriteLine("Hello, World!");

            Ocean myOcean = new Ocean();
            myOcean.Initialize();

            myOcean.Run();

            

            Console.WriteLine("press anykey to close app...");
            Console.ReadKey();
        }
    }
}
