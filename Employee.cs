using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class Employee
    {
        public string name;
        public float wage;

        

        public Employee(string name, float wage)
        {
            this.name = name;
            this.wage = wage;
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Name: {name}, Wage: {wage}kr/h");
        }



    }
}
