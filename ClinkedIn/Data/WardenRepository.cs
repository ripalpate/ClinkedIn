﻿using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class WardenRepository
    {
        static List<Warden> _wardens = new List<Warden>();
        public Warden AddWarden(string username, string password)
        {
            var newWarden = new Warden(username, password);

            newWarden.Id = _wardens.Count + 1;

            _wardens.Add(newWarden);

            return newWarden;
        }
    }
}
