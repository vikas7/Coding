using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReaderWriterLock
{
    class Program
    {
        static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static Dictionary<int, string> dic = new Dictionary<int, string>();
        static Random random = new Random();

        static void Main(string[] args)
        {

            var task1 = Task.Factory.StartNew(Read);
            var task2 = Task.Factory.StartNew(Write,"Cazton");
            var task3 = Task.Factory.StartNew(Write, "Vikas");
            var task4 = Task.Factory.StartNew(Read);
            Task.WaitAll(task1, task2, task3, task4);
        }
        static void Read()
        {
            readerWriterLockSlim.EnterReadLock();
            Thread.Sleep(2000);
            readerWriterLockSlim.ExitReadLock();
        }
        static void Write(object user)
        {
            for (int i = 0; i < 10; i++)
            {

                int id = GetRandom();
                readerWriterLockSlim.EnterWriteLock();
                var person = "Person" + i;
                dic.Add(id, person);
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine(user + " added " + person);
                Thread.Sleep(250);
            }

        }

        private static int GetRandom()
        {
            return random.Next(2000, 5000);
        }
    }
}
