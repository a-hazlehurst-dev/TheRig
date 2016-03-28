using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Graphic : Item
    {
        public int Speed { get; set; }
        public int Capacity { get; set; }
        public Graphic()
        {
            Type = "Graphic";
            ComponentTypeId = 3;
        }
    }
}
