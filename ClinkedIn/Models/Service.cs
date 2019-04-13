using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public Service(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public Service(int id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

    }
}
