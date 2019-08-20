using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedResources
{
    class Program
    {
        private static bool isCompleted = false;
        public static readonly Object lockCompleted = new object();

        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            thread.Start();
            HelloWorld();
        }

        private static void HelloWorld()
        {
            lock (lockCompleted)
            {

                if (!isCompleted)
                {
                    isCompleted = true;
                    Console.WriteLine("Print only once");
                }
            }
        }
    }
}
