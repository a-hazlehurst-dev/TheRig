using System.Collections.Generic;
using System.Linq;

namespace TheRig.Models.Components.Sockets
{
    public class GraphicSocketArray : ISocketArray
    {
        public Dictionary<int, ISocket> Sockets { get; private set; }
        public int Max { get; private set; }

        public GraphicSocketArray(int size)
        {
            Max = size;
            Sockets = new Dictionary<int, ISocket>();
            for (int x = 0; x < Max; x++)
            {
                Sockets.Add(x, new GraphicsSocket { IsInstalled = false });
            }
        }

        public bool IsAnyAvailableStockets()
        {
            return Sockets.Any(x => x.Value.IsInstalled == false);
        }

        public int GetIndexOfAvailableSocket()
        {
            foreach (var cpu in Sockets)
            {
                if (cpu.Value.IsInstalled == false)
                {
                    return cpu.Key;
                }
            }
            return -1;
        }

        public void Add(Item item)
        {
            if (IsAnyAvailableStockets())
            {
                var id = GetIndexOfAvailableSocket();
                var socket = Sockets[id];
                socket.Item = (Graphic)item;
                socket.IsInstalled = true;
                Sockets[id] = socket;
            }
        }

        public void RemoveAt(int index)
        {
            ISocket socket;
            if (index < Sockets.Count)
            {
                socket = Sockets[index];
                socket.IsInstalled = false;
                socket.Item = null;
                Sockets[index] = socket;
            }
        }
    }
}

