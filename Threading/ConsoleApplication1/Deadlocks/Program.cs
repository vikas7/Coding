using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            object caztonLock = new object();
            object ChnaderLock = new object();
            new Thread(() =>
            {

                lock (caztonLock)
                {
                    Console.WriteLine("cazton lock obtained");
                    Thread.Sleep(2000);
                    lock (ChnaderLock)
                    {
                        Console.WriteLine("chander lock obtained");
                    }
                }
            }).Start();

            lock (ChnaderLock)
            {
                Console.WriteLine("Main thread obtained chnder lock");
                Thread.Sleep(2000);
                lock (caztonLock)
                {
                    Console.WriteLine("Main thread obtained cazton  lock");

                }
            }

        }
    }
}
