using System;
using TheRig.Models;

namespace TheRig.Core
{
    public class Player
    {
        public int Id { get; set; }
        public string ActiveComputerName { get; set; }

        public Blueprint MyActiveBluePrint { get; set; }

        public Player(int id)
        {
            Id = id;
        }


        public void Turn(DateTime gameDate)
        {

        }
    }

    
}