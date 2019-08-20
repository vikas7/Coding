using System;
using System.Threading;
using System.Diagnostics;

namespace ThreadPriorityClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Current thread priority: {0}",
Thread.CurrentThread.Priority);
            Console.WriteLine("Running on all cores available");
            RunThreads();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Running on a single core");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();

            var sampleForeGround=new ThreadSample(10);
            var sampleBackGround=new ThreadSample(15);

            var threadOne=new Thread(sampleBackGround.CountNumbers2);
            threadOne.Name="Background";
            var threadTwo=new Thread(sampleForeGround.CountNumbers2);
            threadTwo.Name="Foreground";
            threadOne.IsBackground=true;
            threadOne.Start();
            threadTwo.Start();
        }

        #region  Thred Priority
        #region ForeGround and Background thread

        #endregion
        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadone = new Thread(sample.CountNumbers);
            threadone.Name = "ThreadOne";

            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";
            threadone.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;

            threadone.Start();
            threadTwo.Start();

            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            sample.Stop();



        }
        #endregion
    }
    class ThreadSample
    {
        private bool _isStopped = false;
        private readonly int _iterations;
        public ThreadSample(){}
        public ThreadSample(int iteratons){
            _iterations=iteratons;
        }
        public void Stop()
        {
            _isStopped = true;
        }
        public void CountNumbers()
        {
            long counter = 0;
            while (!_isStopped)
            {
                counter++;
            }
            Console.WriteLine("{0} with {1} priority " + " has a count ={2}",
            Thread.CurrentThread.Name, Thread.CurrentThread.Priority, counter.ToString("N0"));
        }

        public void CountNumbers2(){
            for(int i=0;i<_iterations;i++){
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name,i);
            }
        }
    }
}
