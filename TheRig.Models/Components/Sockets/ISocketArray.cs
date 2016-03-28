using System.Collections.Generic;

namespace TheRig.Models.Components.Sockets
{
    public interface ISocketArray
    {
        Dictionary<int, ISocket> Sockets { get; }
        int Max { get; }
        bool IsAnyAvailableStockets();
        int GetIndexOfAvailableSocket();
        void Add(Item item);
        void RemoveAt(int index);
    }
}
