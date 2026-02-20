using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Entities
{
    public class Clint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
   
        //Projects
        public ICollection<Project> Projects { get; set; }

    }
}
