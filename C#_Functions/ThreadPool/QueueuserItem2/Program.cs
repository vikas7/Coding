using System;
using System.Threading;

namespace QueueuserItem2
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(WriteName,"Ashish");
            Console.WriteLine("main thread does some work and then it sleeps");
            //Thread.Sleep(2000);
            Console.WriteLine("main thread exits");
        }

        private static void WriteName(object state)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"My name is {state}");
        }
    }
}
