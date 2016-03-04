using System.Collections.Generic;
using TheRig.Models.Components;

namespace TheRig.UI.Controller
{
    public class Player
    {
        public List<Computer> ComputerPool { get; set; }

        public Player()
        {
            ComputerPool = new List<Computer>();
        }

        
    }
}