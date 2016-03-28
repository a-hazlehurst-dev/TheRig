using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRig.Models.Maps;

namespace TheRig.Data.Repositories
{
    public class TileGridRepository
    {
        private List<TileGrid> _context;

        public TileGridRepository(List<TileGrid> context)
        {
            _context = context;
        }

        public TileGrid GetTileGrid(int id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<TileGrid> Find()
        {
            return _context;
        }


    }
}
