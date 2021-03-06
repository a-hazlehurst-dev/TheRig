using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.Models.Components.Sockets;
using TheRig.UI.Controller;
using TheRig.UI.Helper;
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
            UiTitleHelper.DrawBluePrintTitle(_displayController);

            var computer = GameState.Instance.Player.GetActiveComputer();
            Console.WriteLine("Name: \t" + computer.Name);
            Console.Write("\tMotherboard:\t");

            Console.Write(computer.Motherboard != null ? computer.Motherboard.Name : "Not set.");
            Console.WriteLine("(M: To add or change the motherboard.)");
            Console.WriteLine("");
            int count = 1;
            Dictionary<int, ISocket> binding = new Dictionary<int, ISocket>();
            DisplayComponents(computer, SocketType.Cpu, ref count, binding);
            DisplayComponents(computer, SocketType.Ram, ref count, binding);
            DisplayComponents(computer, SocketType.Graphics, ref count, binding);
            DisplayComponents(computer, SocketType.Sound, ref count, binding);


            var sounds = computer.Motherboard.SoundSocketArray;

            Console.WriteLine();
            Console.WriteLine("A: To add components.");
            Console.WriteLine("Press X to return to menu.");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                _displayController.GamePages.ActivePage = _displayController.GamePages.Pages["AddComponents"];
            }
            if (key.Key == ConsoleKey.X)
            {
                Back();
            }

            ISocket socket = null;
            if (key.Key == ConsoleKey.D1)
            {
                socket = binding[1];
            }
            if (key.Key == ConsoleKey.D2)
            {
                socket = binding[2];
            }
            if (key.Key == ConsoleKey.D3)
            {
                socket = binding[3];
            }
            if (key.Key == ConsoleKey.D4)
            {
                socket = binding[4];
            }
            if (key.Key == ConsoleKey.D5)
            {
                socket = binding[5];
            }
            if (key.Key == ConsoleKey.D6)
            {
                socket = binding[6];
            }

            if (socket != null)
            {
                SelectCompatibleOptions(socket, SocketType.Cpu, computer.Motherboard.CpuSocketArray, _displayController.UnitOfWork.CpuRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptions(socket, SocketType.Ram, computer.Motherboard.RamSocketArray, _displayController.UnitOfWork.RamRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptions(socket, SocketType.Graphics, computer.Motherboard.GraphicSocketArray, _displayController.UnitOfWork.GraphicsRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptions(socket, SocketType.Sound,computer.Motherboard.SoundSocketArray, _displayController.UnitOfWork.SoundRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());

                Console.ReadKey();
            }
         
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