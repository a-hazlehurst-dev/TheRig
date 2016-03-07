using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TheRig.Models.Components.Sockets;

namespace TheRig.Models.Components
{
    public class Motherboard : Item
    {

        public RamSocketArray RamSocketArray;
        public CpuSocketArray CpuSocketArray;
        public GraphicSocketArray GraphicSocketArray;
        public SoundSocketArray SoundSocketArray;

        public Motherboard(int numberOfRamSlots, int numberOfCpuSlots, int numberOfGraphicsSlots, int numberOfSoundSlots)
        {
            RamSocketArray = new RamSocketArray(numberOfRamSlots);
            CpuSocketArray = new CpuSocketArray(numberOfCpuSlots);
            GraphicSocketArray = new GraphicSocketArray(numberOfGraphicsSlots);
            SoundSocketArray = new SoundSocketArray(numberOfSoundSlots);
             Name = "NotSet";
        }

        public ISocketArray GetSocketArray(string name)
        {
            ISocketArray socketArray = null;

            if (name.Equals("Cpu"))
            {
                socketArray= CpuSocketArray;
            }
            if (name.Equals("Ram"))
            {
                socketArray = RamSocketArray;
            }
            if (name.Equals("Graphic"))
            {
                socketArray = GraphicSocketArray;
            }
            if (name.Equals("Sound"))
            {
                socketArray = SoundSocketArray;
            }
            return socketArray;
        }


        public int CpuTypeId { get; set; }
        public int RamTypeId { get; set; }
        public int GraphicsTypeId { get; set; }
        public int SoundTypeId { get; set; }


    }
}
