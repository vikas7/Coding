using System;

namespace MaxDiffRootChild
{
    public class Node{
        public int data;
        public Node left, right;
        public Node(int data){
            this.data=data;
            left=right=null;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root=new Node(8);
            root.left=new Node(3);
            root.left.left=new Node(1);
            root.left.right=new Node(6);
            root.left.right.left=new Node(4);
            root.left.right.right=new Node(7);
            root.right=new Node(10);
            root.right.right=new Node(14);
            root.right.right.left=new Node(13);
            int maxDiff=0;

            Console.WriteLine(MaxDiff(root,ref maxDiff));
        }

        static int MaxDiff(Node root,ref int maxDiff){
            if(root.left==null && root.right==null){
                return root.data;
            }
            int leftMin=root.left!=null?MaxDiff(root.left,ref maxDiff):0;
            int rightMin=root.right!=null?MaxDiff(root.right, ref maxDiff):0;

            if(maxDiff<root.data-leftMin){
                maxDiff=root.data-leftMin;
            }
            if(maxDiff<root.data-rightMin){
                maxDiff=root.data-rightMin;
            }
            return root.data>leftMin
                 ?(leftMin>rightMin?rightMin:leftMin)
                 :(root.data>rightMin?rightMin:root.data);


        }
    }
}
