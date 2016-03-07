using TheRig.Models.Components.Sockets;

namespace TheRig.Models.Components.Sockets
{
    public class SoundSocket : ISocket
    {
        public string Type { get { return "Sound"; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}