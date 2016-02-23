using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces
{
    public interface IDataProvider
    {
        List<Motherboard> GetMotherboards();
        List<Ram> GetRam();
        List<Cpu> GetCpus();
        List<Graphic> GetGraphics();
        List<Sound> GetSounds();
    }
}
