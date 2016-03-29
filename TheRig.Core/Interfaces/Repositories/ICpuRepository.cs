using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces.Repositories
{
    public interface ICpuRepository
    {
        Cpu Get(string id);
        IEnumerable<Cpu> Find();
        IEnumerable<Cpu> GetCompatible(Motherboard motherboard);
    }
}
