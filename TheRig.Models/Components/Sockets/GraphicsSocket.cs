namespace TheRig.Models.Components.Sockets
{ 

    public class GraphicsSocket : ISocket
    {
        public string Type { get { return "Graphic"; } }
        public bool IsInstalled { get; set; }
        public Item Item { get; set; }
    }
}