using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ServiceRepository
    {
        static List<Service> _services = new List<Service>();

        public Service AddService(string name, decimal cost)
        {
            var newService = new Service(name, cost);

            newService.Id = _services.Count + 1;

            _services.Add(newService);

            return newService;

        }
    }
}
