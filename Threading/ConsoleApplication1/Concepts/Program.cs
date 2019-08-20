using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concepts
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintSomething);
            thread.Start();
            thread.Join();
            Console.WriteLine("Main method printed");
        }

        private static void PrintSomething()
        {

            Thread.Sleep(5000);
            Console.WriteLine("PrintSomthing printed");
        }
    }
}
