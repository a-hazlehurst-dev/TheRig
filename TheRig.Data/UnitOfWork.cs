using TheRig.Core.Interfaces;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Data.Repositories;

namespace TheRig.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRamRepository RamRepository { get; private set; }
        public ICpuRepository CpuRepository { get; private set; }
        public IGraphicRepository GraphicsRepository { get; private set; }
        public ISoundRepository SoundRepository { get; private set; }
        public IMotherboardRepository MotherboardRepository { get; set; }

        public UnitOfWork(IDataProvider dataProvider)
        {

            RamRepository = new RamRepository(dataProvider.GetRam());
            CpuRepository = new CpuRepository(dataProvider.GetCpus());
            GraphicsRepository = new GraphicRepository(dataProvider.GetGraphics());
            SoundRepository = new SoundRepository(dataProvider.GetSounds()); 
            MotherboardRepository = new MotherboardRepository(dataProvider.GetMotherboards());

        }


    }
}
