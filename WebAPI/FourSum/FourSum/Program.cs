using System;
using System.Collections.Generic;
using System.Collections;

public class Node
{
    public int f;
    public int l;
    public Node(int f, int l)
    {
        this.l = l;
        this.f = f;
    }
}
public class GFG
{
    static public void Main()
    {
        int t = Convert.ToInt32(Console.ReadLine());
        while (t-- > 0)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');

            int val = Convert.ToInt32(Console.ReadLine());
            int[] ia = new int[n];

            for (int i = 0; i < n; i++)
            {
                ia[i] = Convert.ToInt32(str[i]);
            }

            Dictionary<int, List<Node>> dict = new Dictionary<int, List<Node>>();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int sum = ia[i] + ia[j];
                    int rem = val - sum;

                    if (dict.ContainsKey(rem))
                    {

                        List<Node> li = dict[rem];

                        foreach (Node nn in li)
                        {

                            int fi = nn.f;
                            int la = nn.l;
                            if ((fi != i && fi != j) && (la != i && la != j))
                            {
                                count++;
                            }
                        }
                    }

                    if (dict.ContainsKey(sum))
                    {
                        List<Node> li = dict[sum];
                        li.Add(new Node(i, j));
                        dict.Remove(sum);
                        dict.Add(sum, li);
                    }
                    else
                    {
                        List<Node> li = new List<Node>();
                        li.Add(new Node(i, j));
                        dict.Add(sum, li);
                    }
                }
            }
            if (count > 0)
            {
                Console.WriteLine("1");
            }else
            {
                Console.WriteLine("0");
            }
            
        }
    }
}