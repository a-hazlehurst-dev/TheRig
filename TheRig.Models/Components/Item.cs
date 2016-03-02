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
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int TileGridId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int ComponentTypeId { get; set; }
    }
}
