using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }

        //Department
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        //clint 
        public int? ClintId { get; set; }    
        public Clint? Clint { get; set; }

        //Employees
        
        public ICollection<Employee> Employees { get; set; }
    }
}
