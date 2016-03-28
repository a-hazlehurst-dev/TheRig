namespace TheRig.Models.Components.Sockets
{
    public class CpuSocket :ISocket
    {
        public SocketType Type { get { return SocketType.Cpu; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}