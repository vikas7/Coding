using System;

namespace CopyAndClone
{
    class Employee{
        public string  Name { get; set; }  
        public int Age { get; set; }  
        public Employee(string name, int age){
            Name=name;
            Age=age;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1=new Employee("Vikas",28);
            Employee emp2=emp1;
            emp2.Age=40;
            Console.WriteLine("emp1 Age is "+emp1.Age);
            Console.WriteLine("emp2 Age is "+emp2.Age);

            Employee emp3=(Employee)emp1.Clone();

        }
    }
}
