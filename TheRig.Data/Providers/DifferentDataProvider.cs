using System.Collections.Generic;
using TheRig.Core.Interfaces;
using TheRig.Models.Components;

namespace TheRig.Data.Providers
{
    public class differentDataPRovider : IDataProvider
    {
        public List<Motherboard> GetMotherboards()
        {
            return new List<Motherboard> { new Motherboard { Id = 1, Name = "New Motherboard", GraphicsTypeId = 1, CpuTypeId = 1, TypeId = 1, RamTypeId = 1, SoundTypeId = 1, TileGridId = 1 } };
        }

        public List<Ram> GetRam()
        {
            return new List<Ram>
            {
                new Ram { Id =1, Name = "New Ram1" , TypeId = 1},
                new Ram { Id =1, Name = "New Ram2" , TypeId = 1}
            };
        }

        public List<Cpu> GetCpus()
        {
            return new List<Cpu>
            {
                new Cpu { Id =1, Name = "New Cpu" , TypeId = 1},
                new Cpu { Id =1, Name = "New cpu1" , TypeId = 1}
            };
        }

        public List<Graphic> GetGraphics()
        {
            return new List<Graphic>
            {
                new Graphic { Id =1, Name = "New Graphic23" , TypeId = 1},
                new Graphic { Id =1, Name = "New Graphic235" , TypeId = 1}
            };
        }

        public List<Sound> GetSounds()
        {
            return new List<Sound>
            {
                new Sound { Id =1, Name = "New Sound2" , TypeId = 1},
                new Sound { Id =1, Name = "New Sound45" , TypeId = 1}
            };
        }
    }
}
