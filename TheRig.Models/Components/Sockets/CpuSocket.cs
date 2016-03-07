namespace TheRig.Models.Components.Sockets
{
    public class CpuSocket :ISocket
    {
        public string Type { get { return "Cpu"; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}