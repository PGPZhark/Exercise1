using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Exercise1
{
    internal class Program
    {
        static string path = Path.Combine(Environment.CurrentDirectory + "\\employees.txt");

        

        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            bool runProgram = true;

            if (!File.Exists(path))
            {
                Console.WriteLine("Employee data file does not exist");
                Console.WriteLine("Employee data file created");
                File.CreateText(path);
            }
            else
            {
                Console.WriteLine("Employee data file exists");
            }
            Console.Clear();

            do
            {
                string command;
                Console.WriteLine(" Commands ");
                Console.WriteLine("1: Register employee");
                Console.WriteLine("2: View all employees");
                Console.WriteLine("3: Save Employee List");
                Console.WriteLine("4: Load Employee List");
                Console.WriteLine("5: Clear Saved Employee List");
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
                    case "3":
                        SaveList(employees);
                        Console.WriteLine("Saved!");
                        break;
                    case "4":
                        LoadList(employees);
                        break;
                    case "5":
                        employees.Clear();
                        SaveList(employees);
                        Console.WriteLine("Saved data deleted");
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

            static void SaveList(List<Employee> employees)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Employee employee in employees)
                {
                    sb.Append($"name:{employee.name};");
                    sb.Append($"wage:{employee.wage};");
                    sb.Append(Environment.NewLine);
                }
                File.WriteAllText(path, sb.ToString());
                

            }

            static void LoadList(List<Employee> employees)
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    string[] employeesAsString = File.ReadAllLines(path);
                    for (int i = 0; i < employeesAsString.Length;i++)
                    {
                        string[] employeeSplits = employeesAsString[i].Split(';');
                        string name = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                        float wage = float.Parse(employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1));

                        Employee employee = null;

                        employee = new Employee(name, wage);

                        employees.Add(employee);
                    }

                    Console.WriteLine($"Loaded {employees.Count} employees.\n\n");

                }



            }



        }
    }
}
