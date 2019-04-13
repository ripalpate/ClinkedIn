using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class UpdateService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Service(int id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
