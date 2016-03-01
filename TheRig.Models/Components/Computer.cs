using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Computer
    {
        public Computer()
        {
            Motherboard = new Motherboard {Name = "Not Set"};
        }
        public Motherboard Motherboard { get; set; }
        public string Name { get; set; }


    }
}
