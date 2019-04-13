using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class ServiceRepository
    {
        public List<Service> _services = new List<Service>
        {
            new Service (1,"software as a service",3.50),
            new Service (2,"cleaning",4.50),
            new Service (3,"mopping",5.50),
            new Service (4,"sweeping",6.50),
            new Service (5,"windowing",7.50)
        };

        public List<Service> GetServices()
        {
            return _services;
        }

        public Service AddService(string name, double cost)
        {
            var newService = new Service(name, cost);

            newService.Id = _services.Count + 1;

            _services.Add(newService);            

            return newService;

        }

        public List<Service> UpdateService()
        {
            return _services;
        }

        public List<Service> DeleteService(int id)
        {
            var listOfServices = _services;

            var serviceToBeRemoved = (from service in listOfServices
              where (service.Id == id)
                select service).ToList();

            _services.Remove(serviceToBeRemoved.First());

            var remainingServices = _services.ToList();

            return remainingServices;

        }

    }
}
