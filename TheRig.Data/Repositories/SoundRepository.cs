using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data.Repositories
{
    public class SoundRepository : ISoundRepository
    {
        private List<Sound> _context;

        public SoundRepository(List<Sound> context)
        {
            _context = context;
        }

        public Sound GetSound(int id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Sound> Find()
        {
            return _context;
        }

        public IEnumerable<Sound> GetCompatible(Motherboard motherboard)
        {
            return _context.Where(x => x.TypeId == motherboard.SoundTypeId);
        }


    }
}
