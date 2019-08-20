using System;

namespace EvenLengthSubstring
{
    class Program
    {
        static public void Main () {
		int t=Convert.ToInt32(Console.ReadLine());
		while(t-->0){
		    string s=Console.ReadLine();
		    char[] ch=s.ToCharArray();
		    int maxl=0;
		    
		    int l=ch.Length;
		    int sl=2;
		    if(l<=1){
		        Console.WriteLine("0");
		    }else{
		        for(int i=2;i<=l;i=i+2){
		            
		            for(int j=0;j<=l-i;j++){
		                string sub=s.Substring(j,i);
		                bool s_t=SumIsEqual(sub);
		                
		                if(s_t){
		                    if(maxl<i){
		                        maxl=i;
		                    }
		                }
		            }
		        }
		    }
		    Console.WriteLine(maxl);
		}
	}
	public static bool SumIsEqual(string sub){
	    int len=sub.Length;
	    int mid=len/2;
	    char[] cc=sub.ToCharArray();
	    
	    int sum1=0;int sum2=0;
	    for(int i=0;i<mid;i++){
	        sum1=sum2+(int)cc[i];
	        sum2=sum2+(int)cc[mid+i];
	    }
	    if(sum1==sum2){
	        return true;
	    }else{
	        return false;
	    }
	}
    }
}
