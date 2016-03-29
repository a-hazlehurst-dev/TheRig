using TheRig.Core.Interfaces.Repositories;

namespace TheRig.Core.Interfaces
{
    public interface IGameData
    {
        IManufacturerRepository ManufacturerRepository { get; }
    }
}
