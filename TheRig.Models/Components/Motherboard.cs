using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.Models.Components
{
    public class Motherboard : Item
    {

        public Motherboard(int numberOfRamSlots, int numberOfCpuSlots, int numberOfGraphicsSlots, int numberOfSoundSlots)
        {
            RamSlots =new List<Ram>();
            CpuSlots = new List<Cpu>();
            GraphicsSlots = new List<Graphic>();
            SoundSlots = new List<Sound>();

            NumberOfRamSlots = numberOfRamSlots;
            NumberOfCpuSlots = numberOfCpuSlots;
            NumberOfGraphicsSlots = numberOfGraphicsSlots;
            NumberOfSoundSlots = numberOfSoundSlots;
            
            for (int x = 0; x < numberOfRamSlots; x++)
            {
                RamSlots.Add(new Ram {Name = "Not set."});
            }
            for (int x = 0; x < numberOfCpuSlots; x++)
            {
                CpuSlots.Add(new Cpu { Name = "Not set."});
            }
            for (int x = 0; x < numberOfGraphicsSlots; x++)
            {
                GraphicsSlots.Add(new Graphic { Name = "Not set." });
            }
            for (int x = 0; x < numberOfSoundSlots; x++)
            {
                SoundSlots.Add(new Sound { Name = "Not set." });
            }
            Name = "NotSet";
        }


        public int CpuTypeId { get; set; }
        public int RamTypeId { get; set; }
        public int GraphicsTypeId { get; set; }
        public int SoundTypeId { get; set; }

        public int NumberOfCpuSlots { get; set; }
        public int NumberOfRamSlots { get; set; }
        public int NumberOfGraphicsSlots { get; set; }
        public int NumberOfSoundSlots { get; set; }

        public List<Ram>  RamSlots { get; set; }
        private List<Cpu> _cpus; 
        public List<Cpu> CpuSlots
        {
            get { return _cpus; }
            set
            {
                if (value.Count > MaxCpu)
                {
                    while (value.Count>MaxCpu)
                    {
                        value.RemoveAt(0);
                    }
                }
                _cpus = value;

            } 
        }

        public List<Graphic> GraphicsSlots { get; set; }
        public List<Sound> SoundSlots { get; set; }

        public int MaxRam { get; set; }
        public int MaxCpu { get; set; }
        public int MaxGraphics { get; set; }
        public int MaxSound { get; set; }


    }
}
