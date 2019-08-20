using System;
public class GFG {
	static public void Main () {
		int t=Convert.ToInt32(Console.ReadLine());
		while(t-->0){
		    int[,] ar=new int[9,9];
		    
		    for(int i=0;i<9;i++){
		        string[] st=Console.ReadLine().Split(' ');
		        
		        for(int j=0;j<9;j++){
		            ar[i,j]=Convert.ToInt32(st[j]);
		            Console.Write(ar[i,j]);
		        }
		        Console.WriteLine();
		    }
		}
		
	}
}