using System;
using System.Collections.Generic;

namespace CSharpArray
{
    public class CDE{
        public CDE(string str){
            Console.WriteLine(str);
        }
    }
    public class ABC{
        CDE cd=new CDE("variable method");
        public ABC(string st){
            CDE ff=new CDE("Constructor");
        }
    }
    class Program
    {
      //  static ABC c =new ABC("This is called from variable");
        static void Main(string[] args)
        {
            int[] ar=new int[]{5,4,3,2,1};
            Array.Sort(ar,new Comparison<int>((a,b)=> a.CompareTo(b)));
            Array.ForEach(ar, x => Console.Write(x +" "));
            Console.WriteLine();
            Console.WriteLine(DateTime.UtcNow.Date);
        //     ABC dn=new ABC("this is called fomr Main method");
        //   // Console.WriteLine("This is progam class");

        // var actions = new List<Action>();
        //     for (int i = 0; i < 4; i++)
        //         actions.Add(() => Console.WriteLine(i));
        //     foreach (var action in actions)
        //         action();
        }
    }
}
