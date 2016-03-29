using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public ComponentTypeEnum ComponentType { get; set; }
        public int Owner { get; set; }
    }


    public enum ComponentTypeEnum
    {
        Motherboard = 1,
        Ram = 2,
        Cpu = 3,
        Graphics = 4,
        Sound = 5
    }
}
