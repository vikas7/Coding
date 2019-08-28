using System;

namespace WildCardPatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string str="baaabab";
            string pattern="*****ba*****ab"
            if(StrMatch(str, pattern)){
                Console.WriteLine("Yes");
            }else{
                Console.WriteLine("No");
            }
        }
    }
}
