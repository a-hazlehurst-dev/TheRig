using System.Collections.Generic;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces
{
    public interface  IUnitOfWork
    {
        IMotherboardRepository MotherboardRepository { get; }
        ICpuRepository CpuRepository { get;  }
        IRamRepository RamRepository { get; }
        ISoundRepository SoundRepository { get;  }
        IGraphicRepository GraphicsRepository { get; }
        

        List<Item> GetAll();
        List<Item> GetCompatibleItems(Motherboard motherboard);
    }
}
