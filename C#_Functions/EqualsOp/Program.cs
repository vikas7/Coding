using System;
using System.Text;

namespace EqualsOp
{
    public class ObClass{
        int age;
        public ObClass(int age){
            this.age=age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        //    int f=10;
        //    int s=10;

           string st1="ABC";
           string st2="ABC";

           Console.WriteLine("object.ReferenceEquals(st1, st2)"+object.ReferenceEquals(st1, st2));

        //    String st3=new String("BGR");
        //    String st4=new String("BGR");
        //     String st5=st4;

            StringBuilder sb1=new StringBuilder("ABC");
            StringBuilder sb2=new StringBuilder("AB");
            string sb3=sb2.Append("C").ToString();
            string sb4="ABC";

            Console.WriteLine(sb3==sb4);
            Console.WriteLine(object.ReferenceEquals(sb3,sb4));
            Console.WriteLine("Sb1 and sb2 reference equal: "+object.ReferenceEquals(sb1,sb2));


            ObClass ob1=new ObClass(10);
            ObClass ob2=new ObClass(10);
            ObClass ob3=ob2;


            Console.WriteLine("ObClass class .....................");
            Console.WriteLine(ob1==ob2);;
            Console.WriteLine(ob1.Equals(ob2));

             Console.WriteLine(ob3==ob2);
            Console.WriteLine(ob3.Equals(ob2));

            Console.WriteLine("StringBUilder class........................");
            Console.WriteLine(sb1==sb2);
           Console.WriteLine(sb1.Equals(sb2));



        //    Console.WriteLine(f==s);
        //    Console.WriteLine(f.Equals(s));

        //    Console.WriteLine(st1==st2);
        //    Console.WriteLine(st1.Equals(st2));

        //    Console.WriteLine(st3==st4);
        //    Console.WriteLine(st3.Equals(st4));

        //    Console.WriteLine(st5==st4);
        //    Console.WriteLine(st5.Equals(st4));


        }
    }
}
