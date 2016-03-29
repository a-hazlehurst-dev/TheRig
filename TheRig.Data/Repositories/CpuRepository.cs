using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data.Repositories
{
    public class CpuRepository : ICpuRepository
    {
        public List<Cpu> _context;

        public CpuRepository(List<Cpu> context)
        {
            _context = context;
        }

        public Cpu Get(string id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Cpu> Find()
        {
            return _context;
        }

        public IEnumerable<Cpu> GetCompatible(Motherboard motherboard)
        {
            return _context.Where(x => x.TypeId == motherboard.CpuTypeId);
        }

    }
}
