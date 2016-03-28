using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces.Repositories
{
    public interface IGraphicRepository
    {
        Graphic GetGraphic(int id);
        IEnumerable<Graphic> Find();
        IEnumerable<Graphic> GetCompatible(Motherboard motherboard);
    }
}
