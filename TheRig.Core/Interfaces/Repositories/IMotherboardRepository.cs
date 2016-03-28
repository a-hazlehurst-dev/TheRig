using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces.Repositories
{
    public interface  IMotherboardRepository
    {
        Motherboard GetMotherboard(int id);
        IEnumerable<Motherboard> Find();
    }
}
