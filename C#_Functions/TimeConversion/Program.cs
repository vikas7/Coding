using System;
using System.Collections.Generic;

public class GFG {
	static public void Main () {
		int t=Convert.ToInt32(Console.ReadLine());
		while(t-->0){
		    string[] s1=Console.ReadLine().Split(' ');
		    string[] s2=Console.ReadLine().Split(' ');
		    
		    int len=Convert.ToInt32(s1[0]);
		    int sum=Convert.ToInt32(s1[1]);
		    int[] a=new int[len];
		    
		    for(int i=0;i<len;i++){
		        a[i]=Convert.ToInt32(s2[i]);
		    }
		    
		    Dictionary<int, HashSet<int>> dic=new Dictionary<int,HashSet<int>>();
		    List<HashSet<int>> ls=new List<HashSet<int>>();
		    
		    for(int i=0;i<len;i++){
		        
		        for(int j=i+1;j<len;j++){
                    
		            int su=a[i]+a[j];
		            int need=sum-su;
		            
		            HashSet<int> hs=new HashSet<int>();
		            hs.Add(i);
		            hs.Add(j);
		            
		            if(dic.ContainsKey(need)){
		                HashSet<int> val=dic[need];
		                if(!val.Contains(i) && !val.Contains(j)){
		                    HashSet<int> rest=new HashSet<int>(hs);
		                    rest.UnionWith(val);
		                    ls.Add(rest);
		                }
		            }
		            if(!dic.ContainsKey(su)){
		                 dic.Add(su, hs);
		            }
		        }
		    }
		    ls.ForEach( it =>
		    {
		        foreach(int i in it)
		        { 
		            Console.Write(i+" ");
		            
		        }
		        Console.Write("$");
		        
		    });
		    
		    Console.WriteLine();
		    
		}
	}
}