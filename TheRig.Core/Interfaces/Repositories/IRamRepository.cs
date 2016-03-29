using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces.Repositories
{
    public interface IRamRepository
    {
        Ram GetItem(string id);
        IEnumerable<Ram> GetCompatible(Motherboard motherboard);
        IEnumerable<Ram> Find();
    }
}
