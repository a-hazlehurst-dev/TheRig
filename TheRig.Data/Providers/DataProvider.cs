using System.Collections.Generic;
using TheRig.Core.Interfaces;
using TheRig.Models.Components;

namespace TheRig.Data.Providers
{
    public class DataProvider : IDataProvider
    {
        public List<Motherboard> GetMotherboards()
        {
            return new List<Motherboard>
            {
                new Motherboard(2, 1, 1, 1) {Id =1, RamTypeId = 1, Name = "Mobo1", CpuTypeId = 1, GraphicsTypeId = 1, SoundTypeId = 3, MaxCpu = 1, MaxGraphics = 1, MaxRam = 2, MaxSound = 1},
                new Motherboard(2, 1, 1, 1) {Id= 2, RamTypeId = 2,Name = "Mobo2", CpuTypeId = 2, GraphicsTypeId = 2, SoundTypeId = 2, MaxCpu = 1, MaxGraphics = 1, MaxRam = 4, MaxSound = 1},
                new Motherboard(4,1,1,1) {Id= 3, RamTypeId = 2,Name = "Mobo3", CpuTypeId = 2, GraphicsTypeId = 3, SoundTypeId = 1, MaxCpu = 2, MaxGraphics = 2, MaxRam = 6, MaxSound = 1}
            };
        }
        public List<Ram> GetRam()
        {
            return new List<Ram>
            {
                new Ram {Id = 1, TypeId = 1, Name = "Ram1", Speed = 1, Capacity = 5, Price = 50.0M},
                new Ram {Id = 2, TypeId = 1, Name = "Ram2", Speed = 1, Capacity = 8, Price = 70.0M},
                new Ram {Id = 3, TypeId = 2, Name = "Ram3", Speed = 2, Capacity = 5, Price = 60.0M},
                new Ram {Id = 4, TypeId = 2, Name = "Ram4", Speed = 2, Capacity = 8, Price = 75.0M},
                new Ram {Id = 5, TypeId = 2, Name = "Ram5", Speed = 2, Capacity = 10, Price = 90.0M},
                new Ram {Id = 6, TypeId = 2, Name = "Ram6", Speed = 2, Capacity = 12,  Price = 120.0M}
            };
        }
        public List<Cpu> GetCpus()
        {
            return new List<Cpu>
            {
                new Cpu {Id = 1, TypeId = 1, Name = "Cpu1", Speed = 1, Price = 98.00M},
                new Cpu {Id = 2, TypeId = 1, Name = "Cpu2", Speed = 1, Price = 79.00M},
                new Cpu {Id = 3, TypeId = 1, Name = "Cpu3", Speed = 2, Price = 140.00M},
                new Cpu {Id = 4, TypeId = 1, Name = "Cpu5", Speed = 2, Price = 152.00M},
                new Cpu {Id = 5, TypeId = 2, Name = "Cpu6", Speed = 2, Price = 132.00M},
                new Cpu {Id = 6, TypeId = 2, Name = "Cpu7", Speed = 3, Price = 211.00M}
            };

        }
        public List<Graphic> GetGraphics()
        {
            return new List<Graphic>
            {
                new Graphic {Id = 1, Name = "Graphic1", TileGridId = 1, TypeId = 1 , Speed = 1, Price = 100.00M},
                new Graphic {Id = 2, Name = "Graphic2", TileGridId = 1, TypeId = 1, Speed = 2, Price = 120.00M},
                new Graphic {Id = 3, Name = "Graphic3", TileGridId = 2, TypeId = 2, Speed = 2, Price = 132.00M},
                new Graphic {Id = 4, Name = "Graphic4", TileGridId = 2, TypeId = 2, Speed = 3, Price = 175.00M},
                new Graphic {Id = 5, Name = "Graphic5", TileGridId = 2, TypeId = 2, Speed = 4, Price = 250.00M},
                new Graphic {Id = 6, Name = "Graphic6", TileGridId = 3, TypeId = 3, Speed = 4, Price = 239.00M},
                new Graphic {Id = 7, Name = "Graphic7", TileGridId = 3, TypeId = 3, Speed = 5, Price = 310.00M},
            };
        }
        public List<Sound> GetSounds()
        {
            return new List<Sound>
            {
                new Sound {Id = 1, Name = "Sound1", TileGridId = 1, TypeId = 1},
                new Sound {Id = 2, Name = "Sound2", TileGridId = 1, TypeId = 1},
                new Sound {Id = 3, Name = "Sound3", TileGridId = 2, TypeId = 2},
                new Sound {Id = 4, Name = "Sound4", TileGridId = 3, TypeId = 3},
                new Sound {Id = 5, Name = "Sound5", TileGridId = 2, TypeId = 2},
                new Sound {Id = 6, Name = "Sound6", TileGridId = 3, TypeId = 3},
                new Sound {Id = 7, Name = "Sound7", TileGridId = 3, TypeId = 3},
            };
        }
    }
}
