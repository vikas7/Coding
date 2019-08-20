using System;
using System.Collections.Generic;
using System.Linq;

namespace OverrideFunction1
{
    class Program
    {


        public static void Main()
        {
            List<String> li=new List<String>(){"ABNCD","EFGH"};
            List<String> li2=new List<string>(){"KIOJ","GY"};
            li2=li;
            li2.ForEach( itee=> Console.WriteLine(itee));
        
            Double zero = 0;
            Console.WriteLine(-1/zero);
            Boolean tt=false;
            if(tt=true){
                Console.WriteLine("this ");
            }

            // This condition will return false.
            if ((zero / zero) == Double.NaN)
                Console.WriteLine("0 / 0 can be tested with Double.NaN.");
            else
                Console.WriteLine("0 / 0 cannot be tested with Double.NaN; use Double.IsNan() instead.");
            int? i = null;
            i++;
            Console.WriteLine("Value of i is {0} ", i);
            double dVal = 100.1;
            Console.WriteLine((int)dVal);
            object obb = 100;
            int tee = (int)obb;

            int x = 1975;
            int y = 2015;
            int z = x ^ y;
            int zz = y ^ z;
            x ^= y ^= x ^= y;
            Console.WriteLine("x = " + x + "; y = " + y);

            object objVal = dVal;
            Console.WriteLine((int)objVal);
            class1 a = new class3();
            Console.WriteLine(a.DoSomething());
        }
    }

    public class class1
    {
        public virtual string DoSomething()
        {
            return "class1";
        }
    }

    public class class2 : class1
    {
        public override string DoSomething()
        {
            return "class2";
        }
    }

    public class class3 : class2
    {
        public new string DoSomething()
        {
            return "Class3";
        }
    }
}
