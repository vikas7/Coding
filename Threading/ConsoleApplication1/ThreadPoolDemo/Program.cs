using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { Name = "Vikas Singh", CompanyName = "Dell EMC" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayUserInfo), employee);
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Number of processors in this machine is :" + Environment.ProcessorCount);
            
            Console.ReadKey();
        }

        private static void DisplayUserInfo(object employee)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Employee emp = employee as Employee;
            Console.WriteLine("Person name is {0} and company name is {1}", emp.Name, emp.CompanyName);
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}
