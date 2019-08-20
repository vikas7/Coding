using System;
using System.Threading;

namespace CancellationTokenDemo2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region  Cancellation first part
            // CancellationTokenSource cts = new CancellationTokenSource();
            // cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            // cts.Token.Register(() => Console.WriteLine("Canceled2"));
            // ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 100));
            // Console.WriteLine("Press enter to cancel the count");
            // Console.ReadLine();
            // cts.Cancel();
            #endregion
            #region cancellation token part two
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 cancelled"));
            var cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 cancelled"));
            var linkedcts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedcts.Token.Register(() => Console.WriteLine("Linke cts cancelled"));
            cts2.Cancel();
            Console.WriteLine("cts1 cancelled={0} , cts2 cancelled={1} linked cts cancelled={2}",
            cts1.IsCancellationRequested,
             cts2.IsCancellationRequested, linkedcts.IsCancellationRequested);

            #endregion

        }

        private static void Count(CancellationToken token, int v)
        {
            for (int i = 0; i < v; i++)
            {

                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break;
                }
                Console.Write(i + " ");
                Thread.Sleep(200);
            }
        }
    }
}
