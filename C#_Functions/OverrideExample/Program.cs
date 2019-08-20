using System;

namespace OverrideExample
{
    public class A{
        public void One(){
            Console.WriteLine("This is A.One method");
        }
        public virtual void Two(){
            Console.WriteLine("This is A.Two method");
        }
    }
    public class B:A{
        public void One(){
            Console.WriteLine("This is B.One method");
        }
        public  override void Two(){
            Console.WriteLine("This is B.Two method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a=new A();
            A ab=new B();

            a.One();
            a.Two();

            ab.One();
            ab.Two();

            B b=new B();
            b.One();
            b.Two();
        }
    }
}
