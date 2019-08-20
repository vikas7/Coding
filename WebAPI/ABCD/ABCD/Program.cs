using System;
using System.Collections.Generic;

namespace Manhattan
{
    public class Node
    {
        public int xin;
        public int yin;
        public Node(int i, int j)
        {
            xin = i;
            yin = j;
        }
    }
    public class Manhattan
    {
        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                string[] s1 = Console.ReadLine().Split(' ');
                int row = Convert.ToInt32(s1[0]);
                int col = Convert.ToInt32(s1[1]);
                int[,] mat = new int[row, col];

                for (int i = 0; i < row; i++)
                {
                    string[] s2 = Console.ReadLine().Split(' ');
                    for (int j = 0; j < col; j++)
                    {
                        mat[i, j] = Convert.ToInt32(s2[j]);
                    }
                }

                string[] s3 = Console.ReadLine().Split(' ');
                int xs = Convert.ToInt32(s3[0]);
                int ys = Convert.ToInt32(s3[1]);
                int q = Convert.ToInt32(Console.ReadLine());
                int[,] move = new int[row, col];
                while (q-- > 0)
                {
                    string[] s4 = Console.ReadLine().Split(' ');

                    int xd = Convert.ToInt32(s4[0]);
                    int yd = Convert.ToInt32(s4[1]);

                    Console.WriteLine(IsItPossible(mat, move, xs-1, ys-1, xd-1, yd-1, 0));
                }
            }
        }

        public static int IsItPossible(int[,] mat, int[,] move, int indexx, int indexy, int xd, int yd, int movec)
        {

            Queue<Node> qu = new Queue<Node>();
            HashSet<string> visited = new HashSet<string>();
            qu.Enqueue(new Node(indexx, indexy));
            visited.Add(indexx + "" + indexy);
            move[indexx, indexy] = 0;


        //    int val = mat[xs - 1, ys - 1];

            while (qu.Count > 0)
            {
                Node node = qu.Dequeue();
                int xs = node.xin;
                int ys = node.yin;               


                int i = 0, j = mat[xs, ys];               


                while (j >= 0 && i<mat.GetLength(0))
                {
                    AddInto(mat, move, xs, ys, i == 0 ? i : -i, j == 0 ? j : -j, qu, visited);
                    AddInto(mat, move, xs, ys, i, j == 0 ? j : -j, qu, visited);
                    AddInto(mat, move, xs, ys, i == 0 ? i : -i, j, qu, visited);
                    AddInto(mat, move, xs, ys, i, j, qu, visited);
                    j--;
                }     
                
                
            }

            if (move[xd, yd] > 0)
            {   
                return move[xd, yd];
            }
            else
            {
                return -1;
            }
        }
        public static void AddInto(int[,] mat, int[,] move ,int xs, int ys, int i , int j, Queue<Node> qu, HashSet<string> visited)
        {
            int nxs = xs + i;
            int nys = ys + j;
            if (IsSafe(mat, nxs, nys))
            {
                if (!visited.Contains(nxs + "" + nys))
                {
                    move[nxs, nys] = move[xs, ys] + 1;
                    qu.Enqueue(new Node(nxs, nys));
                    visited.Add(nxs + "" + nys);
                }
            }            
        }

        public static bool IsSafe(int[,] mat, int x, int y)
        {
            int row = mat.GetLength(0);
            int col = mat.GetLength(1);
            if ((x >= 0 && x < row) && (y >= 0 && y < col))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}