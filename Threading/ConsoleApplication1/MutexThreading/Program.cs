using System;
using System.Threading;

namespace MutexThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mutexName="CSharpThreadingCookBook";
            using(var m=new Mutex(false,mutexName)){
                if(!m.WaitOne(TimeSpan.FromSeconds(5),false)){
                    Console.WriteLine("Second instance is running !");
                }else{
                    Console.WriteLine("Runnning!");
                    Console.ReadLine();
                    m.ReleaseMutex();
                }
            }
        }
    }
}
