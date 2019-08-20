using System;

namespace PrintPattern
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Enter test cases");
            int t = Convert.ToInt32(Console.ReadLine());
           
            while (t-- > 0)
            {
                Console.WriteLine("Enter the number");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write(n + " ");
                PrintNum(n - 5, n);
            }
        }
        	public static void PrintNum(int n,int t){
	    if(n==t){
	        Console.Write(n+" ");
	        return;
	    }else if(n<0){
	        Console.Write(n+" ");
	        PrintNum(n+5,t);
	        return ;
	    }else{
	        Console.Write(n+" ");
	        PrintNum(n-5,t);
	        return ;
	    }
	   
	}
    }
}
