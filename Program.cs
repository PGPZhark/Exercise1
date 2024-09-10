using System.Collections;
using System.Runtime.CompilerServices;

namespace Exercise1
{
    internal class Program
    {


        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            bool runProgram = true;


            do
            {
                string command;
                Console.WriteLine(" Commands ");
                Console.WriteLine("1: Register employee");
                Console.WriteLine("2: View all employees");
                Console.WriteLine("9: Quit application");
                Console.Write("Your command: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                command = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                switch (command)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        Console.WriteLine(" ");
                        PrintEmployeeList();
                        break;
                    case "9":
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again");
                        break;

                }





                Console.WriteLine(" ");
            } while (runProgram);
            

            void AddEmployee()
            {
                start:
                Console.WriteLine(" ");
                Console.WriteLine("Add Employee: ");
                Console.Write("Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (name == null || name == "")
                {
                    Console.WriteLine("Invalid name");
                    goto start;
                }
                else
                {
                    float wage;

                    try
                    {
                        Console.Write("Wage: ");
#pragma warning disable CS8604 // Possible null reference argument.
                        wage = float.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid wage");
                        Console.WriteLine(ex.Message);
                        goto start;
                    }


                    employees.Add(new Employee(name, wage));
                    Console.WriteLine(" ");
                    Console.WriteLine("Employee registered.");
                    Console.WriteLine(" ");

                }
            }

            void PrintEmployeeList()
            {
                if (employees.Count == 0)
                {
                    Console.WriteLine("No employees yet registered.");
                }
                else
                {
                    for (int i = 0; i < employees.Count; i++)
                    {

                        employees[i].PrintEmployeeDetails();
                    }
                }
            }


        }
    }
}
