using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;
using TheRig.Models.Components.Sockets;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;

namespace TheRig.UI.Pages
{

    public class ComputerDescriptionPage : IPage
    {
        private readonly GameController _displayController;
        
        public ComputerDescriptionPage (GameController displayController)
        {
            _displayController = displayController;
        }

        public void Back()
        {
            _displayController.GoToMainMenu();
        }

        public void DisplayComponents(Computer computer,SocketType socketType,ref int count, Dictionary<int, ISocket> binding )
        {
            
            foreach (var socket in computer.Motherboard.GetSocketArray(socketType).Sockets)
            {
                
                Console.Write("\t"+ socketType + " slot " + socket.Key + ", ");
                if (socketType == SocketType.Graphics)
                {
                    Console.Write("\t");
                }
                else
                {
                    Console.Write("\t\t");
                }

                if (socket.Value.IsInstalled)
                {
                    Console.Write(socket.Value.Item.Name);
                    Console.WriteLine("(" + count + ": To remove.)");
                }
                else
                {
                    Console.Write("Not Installed.");
                    Console.WriteLine("(" + count + ": To install.)");
                }
                
                binding.Add(count, socket.Value);
                count++;
            }
        }

        public void Draw()
        {
         
        }

        public void SelectCompatibleOptions(ISocket socket, SocketType socketType, ISocketArray socketArray, List<Item> compatible )
        {
            if (socket.Type == socketType)
            {
                var index = 1;
                Console.WriteLine("Please select the "+ socketType);
                
                foreach (var item in compatible)
                {
                    Console.WriteLine(index + ", " + item.Name);
                    index++;
                }
                var line = Console.ReadLine();
                int temp = 0;
                if (int.TryParse(line, out temp))
                {
                    temp = temp - 1;
                    if (compatible.Count() > temp)
                    {
                        socketArray.Add(compatible.ElementAt(temp));
                    }
                }
            }
        }

        public void Title()
        {
            return;
        }
    }
}