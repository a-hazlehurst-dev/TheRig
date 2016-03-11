namespace TheRig.Models.Components.Sockets
{ 

    public class GraphicsSocket : ISocket
    {
        public SocketType Type { get { return SocketType.Graphics; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}