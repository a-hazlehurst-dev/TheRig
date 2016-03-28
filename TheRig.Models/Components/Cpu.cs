using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Cpu : Item
    {
        public int Speed { get; set; }
        public Cpu()
        {
            Type = "Cpu";
            ComponentTypeId = 1;
        }
    }
}
