using System;
using System.Collections.Generic;
using System.Linq;
namespace SortDescendidngOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] st=new string[]{"zId 93 12","fp kindle book", "10a echo sow","17g 12 25 6","125 echo dot second generation"};
            // Array.Sort(st, new Comparison<string>((st1, st2)=>st1.CompareTo(st2) ));
            // foreach(string str in st){
            //     Console.WriteLine(str);
            // }

        int[] list= new int[]{0,1,2,3,4,5,6};
        int el=list.FirstOrDefault(number => number<0);
        Console.WriteLine(el);
    
        }
    }
}
