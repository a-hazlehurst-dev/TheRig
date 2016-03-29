using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data.Repositories
{
    public class GraphicRepository : IGraphicRepository
    {
        private List<Graphic> _context;

        public GraphicRepository(List<Graphic> context)
        {
            _context = context;
        }

        public Graphic GetGraphic(string id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Graphic> Find()
        {
            return _context;
        }

        public IEnumerable<Graphic> GetCompatible(Motherboard motherboard)
        {
            return _context.Where(x => x.TypeId == motherboard.GraphicsTypeId);
        }
    }
}
