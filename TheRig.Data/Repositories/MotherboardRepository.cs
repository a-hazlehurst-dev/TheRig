using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data.Repositories
{
    public class MotherboardRepository : IMotherboardRepository
    {
        private List<Motherboard> _context;

        public MotherboardRepository(List<Motherboard> context)
        {
            _context = context;
        }

        public Motherboard GetMotherboard(string id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Motherboard> Find()
        {
            return _context;
        }
    }
}
