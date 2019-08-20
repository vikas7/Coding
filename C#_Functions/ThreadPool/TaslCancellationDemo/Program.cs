using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaslCancellationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int32> task = Task.Run(() => Sum(cts.Token, 10000), cts.Token);

            // Thread.Sleep(5000);
            try
            {
               // cts.Cancel();
                task.ContinueWith((t) => Console.WriteLine("Sum is {0}", t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
                task.ContinueWith((t) => Console.WriteLine("Sum threw :" + t.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);
                task.ContinueWith((t) => Console.WriteLine("sum was cancelled 2"), TaskContinuationOptions.OnlyOnCanceled);
                Console.WriteLine("Sum is : {0}", task.Result);
            }
            catch (AggregateException ag)
            {
                ag.Handle(e => e is OperationCanceledException);
                Console.WriteLine("Sum was cancelled");
            }
            Console.WriteLine(task.Result);
        }

        private static int Sum(CancellationToken cts, object arg)
        {
            int sum = 0;

            for (var i = 0; i < (int)arg; i++)
            {
                cts.ThrowIfCancellationRequested();
                checked
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
