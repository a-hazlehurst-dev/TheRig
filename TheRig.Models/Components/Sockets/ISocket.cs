namespace TheRig.Models.Components.Sockets
{
    public interface ISocket
    {
        SocketType Type { get; }
        bool IsInstalled { get; set; }
        Item Item { get; set; }
    }
}
