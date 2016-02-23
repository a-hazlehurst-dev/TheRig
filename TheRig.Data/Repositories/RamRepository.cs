using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data.Repositories
{
    public class RamRepository  : IRamRepository
    {
        private List<Ram> _items;
        public RamRepository(List<Ram> context)
        {
            _items = context;
        }

        public Ram GetItem(int id)
        {
            return _items.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Ram> GetCompatible(Motherboard motherboard)
        {
            return _items.Where(x => x.TypeId == motherboard.RamTypeId).ToList();
        }
    }
}
