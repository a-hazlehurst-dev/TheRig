using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Motherboard : Item
    {

        public Motherboard()
        {
            Components = new List<Item>();
        }
        public int CpuTypeId { get; set; }
        public int RamTypeId { get; set; }
        public int GraphicsTypeId { get; set; }
        public int SoundTypeId { get; set; }
        public List<Item> Components { get; set; }

        public int MaxRam { get; set; }
        public int MaxCpu { get; set; }
        public int MaxGraphics { get; set; }
        public int MaxSound { get; set; }

    }
}
