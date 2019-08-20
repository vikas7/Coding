using System;

namespace ImplementCompare
{
    public class GFG
    {
        static public void Main()
        {

            Element[] arr = new Element[4];
            arr[0] = new Element("54");
            arr[1] = new Element("546");
            arr[2] = new Element("548");
            arr[3] = new Element("60");
          //  arr[4] = new Element("6");
            Array.Sort(arr);
            Array.Reverse(arr);
            // for (int i = 0; i < arr.Length; i++)
            // {
            //     Console.Write(arr[i].st + " ");
            // }
            string ss="";
		    for(int i=0;i<arr.Length;i++){
		        ss+=arr[i].st;
		    }
		    Console.WriteLine(ss);
        }
    }
    public class Element : IComparable<Element>
    {
        public string st;
        public Element(string el)
        {
            this.st = el;
        }

        public int CompareTo(Element ot)
        {
            int l1=this.st.Length;
            int l2=ot.st.Length;

            if(l1>l2){
                int s1=Convert.ToInt32(this.st.Substring(0,l2));
                int s2=Convert.ToInt32(ot.st.Substring(0,l2));
                if(s1==s2){
                    int s3=Convert.ToInt32(this.st[l2]);
                    int s4=Convert.ToInt32(ot.st[0]);
                    if(s3>s4){
                        return 1;
                    }else{
                        return -1;
                    }
                }else{
                    return s1.CompareTo(s2);
                }


            }else if(l2>l1){
                int s1=Convert.ToInt32(this.st.Substring(0,l1));
                int s2=Convert.ToInt32(ot.st.Substring(0,l1));
                if(s1==s2){
                    int s3=Convert.ToInt32(ot.st[l1]);
                    int s4=Convert.ToInt32(this.st[0]);
                    if(s3>s4){
                        return -1;
                    }else{
                        return 1;
                    }
                }else{
                    return s1.CompareTo(s2);
                }
            }
            else{
                return this.st.CompareTo(ot.st);
            }
        }
    }
}
