using System;

namespace Func_C_
{
    class Program
    {
        delegate double CalPointer(int r);
        static CalPointer cpointer=CalculatedArea;
        static void Main(string[] args)
        {
            
            double area=cpointer.Invoke(10);
            Console.WriteLine(area);

            Action<int> actionPointer=CalculatedArea2;
            actionPointer(20);

            Func<int, double> funcPointer=CalculatedArea;
            Console.WriteLine("Func pointer area calculation :"+funcPointer(20));


        }
        static double CalculatedArea(int r){
            return 3.14*r*r;
        }

        static void CalculatedArea2(int r){
            Console.WriteLine("Action calculated is :"+3.14*r*r);
        }
    }
}
