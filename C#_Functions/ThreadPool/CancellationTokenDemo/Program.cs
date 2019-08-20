using System;
using System.Threading;

namespace CancellationTokenDemo
{
    class Program
    {
        static CancellationTokenSource cts;
        static void Main(string[] args)
        {
            cts=new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(CallCount);
            Console.WriteLine("Press enter to cancel the count");
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
        }

        private static void CallCount(object state)
        {
            Count(cts.Token,100);
        }

        private static void Count(CancellationToken token, int v)
        {
            for(int i=0;i<v;i++){
                if(token.IsCancellationRequested){
                    Console.WriteLine("Count is cancelled");
                    break;
                }
                Console.Write(i+" ");
                Thread.Sleep(200);
            }
            Console.WriteLine("Count is done");
        }
    }
}
