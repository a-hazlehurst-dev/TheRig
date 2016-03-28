using System.CodeDom;
using System.Collections.Generic;
using TheRig.Core.Interfaces;
using TheRig.Core.Interfaces.Repositories;
using TheRig.Data.Repositories;
using TheRig.Models.Components;

namespace TheRig.Data
{
    public class UnitOfWork : IGameData
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

        public List<Item> GetAll()
        {
            List<Item> items = new List<Item>();
            items.AddRange(RamRepository.Find());
            items.AddRange(CpuRepository.Find());
            items.AddRange(GraphicsRepository.Find());
            items.AddRange(SoundRepository.Find());
            items.AddRange(MotherboardRepository.Find());
            return items;
        }

        public List<Item> GetCompatibleItems(Motherboard motherboard)
        {
            List<Item> items = new List<Item>();
            items.AddRange(RamRepository.GetCompatible(motherboard));
            items.AddRange(CpuRepository.GetCompatible(motherboard));
            items.AddRange(GraphicsRepository.GetCompatible(motherboard));
            items.AddRange(SoundRepository.GetCompatible(motherboard));
            return items;
        }


    }
}
