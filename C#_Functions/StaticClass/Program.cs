using System;

namespace StaticClass
{
   public  abstract class AbsClass{
        public AbsClass(){
            Console.WriteLine("this is AbsClass constructor");
        } 
    }
    public class NonStatic :AbsClass{
        static int x=10;
        internal const int consVar=100;
       
        public NonStatic():base(){
            Console.WriteLine("this si Non static constructor");
        }
       public  static void Subtract(int y){
            Console.WriteLine(x+y);
            Console.WriteLine(x=x+10);
        }
    }
    public static class ClassStatic{

        static NonStatic nnn=new NonStatic();
       
        static ClassStatic(){
            Console.WriteLine("this is static class constrcutor");
        }
        public static void Add(int x, int y){
            Console.WriteLine("this is Add method {0}", x+y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            ClassStatic.Add(10,20);
            // NonStatic nonStatic=new NonStatic();
            // NonStatic.Subtract(40);
            // Console.WriteLine(NonStatic.consVar);
        }
    }
}
