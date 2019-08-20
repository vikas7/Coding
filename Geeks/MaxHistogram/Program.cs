using System;
using System.Collections.Generic;

namespace MaxHistogram
{
    class Program
    {
        static int FindMax(int[] ar, int len){
            Stack<int> stack=new Stack<int>();
            int i=0;
            int area=0;
            int currentArea=0;
            while(i<len){
                if(stack.Count==0 || ar[stack.Peek()]<ar[i]){
                    stack.Push(i++);
                }
                else{
                    int index=stack.Peek();
                    stack.Pop();
                    int val=ar[index];
                    currentArea=val*(stack.Count==0?i:i-stack.Peek()-1);
                    if(area<currentArea){
                        area=currentArea;
                    }
                }

            }
            while(stack.Count>0){
                 int index=stack.Peek();
                    stack.Pop();
                    int val=ar[index];
                    currentArea=val*(stack.Count==0?i:i-stack.Peek()-1);
                    if(area<currentArea){
                        area=currentArea;
                    }
            }
            return area;
        }
        static void Main(string[] args)
        {
            int[] ar=new int[]{6,6,6,6,5,20};
            Console.WriteLine(FindMax(ar, ar.Length));
        }
    }
}
