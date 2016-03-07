using TheRig.Models.Components.Sockets;

namespace TheRig.Models.Components.Sockets
{
    public class RamSocket : ISocket
    {
        public string Type { get { return "Ram"; }}
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}