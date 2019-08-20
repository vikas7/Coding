using System;

namespace NumberIsPowerOf2
{
    class Program
    {
        static void Main(string[] args)
        {
           int n=8;
          // int t=((n) & (n-1));
           Console.WriteLine(n!=0 && (n & (n-1))==0);
        }
    }
}
