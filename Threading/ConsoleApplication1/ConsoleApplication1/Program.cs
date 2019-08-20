using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteUsingNewThread);
            Console.WriteLine(Environment.ProcessorCount);
            thread.Name = "Catzon worker";
            Thread thread2 = new Thread(WriteUsingNewThread);
            Thread thread3 = new Thread(WriteUsingNewThread);
            Thread thread4 = new Thread(WriteUsingNewThread);
            thread.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            Thread.CurrentThread.Name = "Main Thread";
            for(int i = 0; i < 1000; i++)
            {
                Console.Write("A" + i + " ");
            }
        }

        public static  void WriteUsingNewThread()
        {
            int i=0;
            while(true){
                Console.WriteLine(i++);
            }
            // for(int i = 0; i < 1000; i++)
            // {
            //     Console.Write("Z" + i+" ");
            // }
        }
    }
}

