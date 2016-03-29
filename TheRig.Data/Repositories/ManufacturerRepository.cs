using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models;

namespace TheRig.Data.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly List<Manufacturer> _context;

        public ManufacturerRepository(List<Manufacturer> context)
        {
            _context = context;
        }

        public List<Manufacturer> All()
        {
            return _context;
        }
        public Manufacturer Get(string id)
        {
            return _context.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
