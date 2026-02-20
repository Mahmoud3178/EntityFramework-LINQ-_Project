using Azure;
using Microsoft.EntityFrameworkCore;
using Project1_EntityFramework.Data;
using Project1_EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _Context;

        public EmployeeService (AppDbContext context)

        {
            _Context = context;
        }

        public void Insert()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Is Statu? (y/n): ");
            bool status = Console.ReadLine().ToLower() == "y";

            // craete new depatrment (هربطهم بال id)
            Console.Write("Enter Department: ");
            string depName = Console.ReadLine();
            Department newDep = new Department { Name = depName, Location = "Default" };

            _Context.Departments.Add(newDep);
            _Context.SaveChanges();
            var emp = new Employee { Name = name, Age = age, Salary = salary, Status=status,DepartmentId=newDep.Id };
            _Context.Employees.Add(emp);
            _Context.SaveChanges();
            Console.WriteLine("Added Successfully!");
        }

        public void Update()
        {
            Console.Write("Enter Employee Id: ");
            int id = int.Parse(Console.ReadLine());
            var emp = _Context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Not Found"); return;
            }
            else
            {
                Console.Write("New Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("New Age: ");
                emp.Age = int.Parse(Console.ReadLine());
                Console.Write("New Salary: ");
                emp.Salary = decimal.Parse(Console.ReadLine());
                Console.Write("New Statu? (y/n): ");
                bool status = Console.ReadLine().ToLower() == "y";

                Console.Write("New Department: ");
                string depName = Console.ReadLine();
                Department newdep = new Department { Name = depName, Location = "Default" };
                _Context.Departments.Add(newdep);
                _Context.SaveChanges(); // مهم عشان Id يتولد
                emp.DepartmentId = newdep.Id;


                _Context.SaveChanges();
                Console.WriteLine("Updated!");
            }

        }

        public void Delete()
        {
            Console.Write("Enter Employee Id: ");
            int id = int.Parse(Console.ReadLine());
            var emp = _Context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) { Console.WriteLine("Not found"); return; }

            _Context.Employees.Remove(emp);
            _Context.SaveChanges();
            Console.WriteLine("Deleted!");
        }

        public void ShowEmp()
        {
            var list = _Context.Employees.ToList();
            foreach (var e in list)
                Console.WriteLine($"ID : {e.Id} | Name: {e.Name} |" +
                    $" Age: {e.Age} |" +
                    $" Salary: {e.Salary} | Statu {e.Status}");
        }

    }
}
