using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Ram : Item
    {
        public int Capacity { get; set; }
        public int Speed { get; set; }

        public Ram()
        {
            Type = "Ram";
        }
    }
}
