using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.Core
{
    public class Player
    {
        public string ActiveComputerName { get; set; }
        public List<Computer> ComputerPool { get; set; }

        public Player()
        {
            ComputerPool = new List<Computer>();
            ActiveComputerName = "Not Set.";
        }


        public Computer GetComputer(string name)
        {
            return ComputerPool.SingleOrDefault(x => x.Name.Equals(name));
        }

        public Computer GetActiveComputer()
        {
            return ComputerPool.SingleOrDefault(x => x.Name.Equals(ActiveComputerName));
        }
        
    }
}