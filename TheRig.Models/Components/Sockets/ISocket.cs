namespace TheRig.Models.Components.Sockets
{
    public interface ISocket
    {
        string Type { get; }
        bool IsInstalled { get; set; }
        Item Item { get; set; }
    }
}
