using Project1_EntityFramework.Data;
using Project1_EntityFramework.Services;

namespace Project1_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            var empService = new EmployeeService(context);

            while (true)
            {
                Console.WriteLine("\n1. Show Employees");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": empService.ShowEmp(); break;
                    case "2": empService.Insert(); break;
                    case "3": empService.Update(); break;
                    case "4": empService.Delete(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid"); break;
                }
            }

        }
    }
}
