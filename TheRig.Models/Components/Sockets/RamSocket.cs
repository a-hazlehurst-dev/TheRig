using TheRig.Models.Components.Sockets;

namespace TheRig.Models.Components.Sockets
{
    public class RamSocket : ISocket
    {
        public SocketType Type { get { return SocketType.Ram; }}
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}