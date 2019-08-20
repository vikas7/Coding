using System;

namespace StringIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s="1 and (2 AND 3";
            string s2="1 and (2 AND 3";
            Console.WriteLine(s.IndexOf("2"));
            
            int index=s.IndexOf("2");
            if(s[index-1]=='('){
                Console.WriteLine("opening parentesis exist at the left");
            }else{
                Console.WriteLine("opening parenthesis does not exist at the left");
            }


            int index2=s.IndexOf("3");

            if( index2+1<s.Length && s[index2+1]==')'){
                Console.WriteLine(" contains closing paranthesis");
            }else{
                Console.WriteLine("Does not contain closing parenthesis");
            }
          // s=s.Insert(index+DigitLengthAdjustment("0"),"(");
          // s=s.Insert(index,"(");




            Console.WriteLine(s);
             

        }
        static int DigitLengthAdjustment(string st){
            int len=st.Length;
                  
                  return len;
        }
    }
}
