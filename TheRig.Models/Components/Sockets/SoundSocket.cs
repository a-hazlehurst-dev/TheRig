using TheRig.Models.Components.Sockets;

namespace TheRig.Models.Components.Sockets
{
    public class SoundSocket : ISocket
    {
        public SocketType Type { get { return SocketType.Sound; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}