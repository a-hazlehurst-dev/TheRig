using TheRig.Core.Interfaces.Repositories;

namespace TheRig.Core.Interfaces
{
    public interface  IUnitOfWork
    {
        IMotherboardRepository MotherboardRepository { get; }
        ICpuRepository CpuRepository { get;  }
        IRamRepository RamRepository { get; }
        ISoundRepository SoundRepository { get;  }
        IGraphicRepository GraphicsRepository { get; }
    }
}
