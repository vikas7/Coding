using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(PrintSomething);
            task.Start();
            Task<string> taskthatReturn = new Task<string>(ReturnSomething);
            taskthatReturn.Start();
            //taskthatReturn.Wait();
            Console.WriteLine(taskthatReturn.Result);
        }

        private static string ReturnSomething()
        {
            return "hello";
        }

        private static void PrintSomething()
        {
            Console.WriteLine("Print Something");
        }
    }
}
