using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Entities
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }

        //Employees
        public ICollection<Employee> Employees { get; set; }

        //projects

        public ICollection<Project> Projects { get; set; }

    }
}
