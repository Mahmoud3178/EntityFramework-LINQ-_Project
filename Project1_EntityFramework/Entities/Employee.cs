using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }

        // Department (ForegnKey)
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        //project (ForegnKey)

        public int? ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
