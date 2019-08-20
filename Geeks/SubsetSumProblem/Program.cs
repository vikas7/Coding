using System;
public class GFG {
	static public void Main () {
		int t=Convert.ToInt32(Console.ReadLine());
		while(t-->0){
		    string[] s=Console.ReadLine().Split(' ');
		    
		    int len=Convert.ToInt32(s[0]);
		    int num=Convert.ToInt32(s[1]);
		    string[] st=Console.ReadLine().Split(' ');
		    int[] ia=new int[len];
		    for(int i=0;i<len;i++){
		        ia[i]=Convert.ToInt32(st[i]);
		    }
		    Console.WriteLine(FindSubset(ia, len,num));
		    
		}
	}
	static bool FindSubset(int[] a, int len, int num){
	    
	    if(num>len){
	        return true;
	    }
	    bool[] dp=new bool[num];
	    for(int i=0;i<num;i++){
	        dp[i]=false;
	    }
	    for(int i=0;i<len;i++){
	        
	        bool[] temp=new bool[num];
	        for(int j=0;j<num;j++){
	            temp[i]=false;
	        }
	        
	        for(int j=0;j<num;j++){
	            if(dp[j]){
	                
	                if(!dp[(j+a[i])%num]){
	                    
	                    temp[(j+a[i])%num]=true;
	                }
	            }
	            
	        }
	        for(int k=0;k<num;k++){
	            if(temp[k]){
	                dp[k]=true;
	            }
	        }
	        dp[a[i]%num]=true;
	        
	    }
	    return dp[0];
	}
}