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
             Name = "Not set.";
        }

        public ISocketArray GetSocketArray(SocketType type)
        {
            ISocketArray socketArray = null;

            if (type== SocketType.Cpu)
            {
                socketArray= CpuSocketArray;
            }
            if (type== SocketType.Ram)
            {
                socketArray = RamSocketArray;
            }
            if (type == SocketType.Graphics)
            {
                socketArray = GraphicSocketArray;
            }
            if (type == SocketType.Sound)
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

    public enum SocketType
    {
        Cpu,
        Ram,
        Graphics,
        Sound,
    }
}
