using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces.Repositories
{
    public interface ISoundRepository
    {
        Sound GetSound(int id);
        IEnumerable<Sound> Find();
        IEnumerable<Sound> GetCompatible(Motherboard motherboard);
    }
}
