using System;

namespace SortStringArray
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] st=new string[]{"55", "546", "548", "60"};
           Array.Sort(st);
           Array.Reverse(st);
            for(int i=0;i<st.Length;i++){
                Console.WriteLine(st[i]);
            }
        }
    }
}
