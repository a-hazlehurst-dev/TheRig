using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.Models.Components.Sockets;
using TheRig.UI.Controller;
using TheRig.UI.Helper;

namespace TheRig.UI.Pages
{

    public class ComputerDescriptionPage : IPage
    {
        private readonly GameController _displayController;
        
        public ComputerDescriptionPage (GameController displayController)
        {
            _displayController = displayController;
        }
        

        public void DisplayComponents(Computer computer, string name,ref int count, Dictionary<int, ISocket> binding )
        {
            
            foreach (var socket in computer.Motherboard.GetSocketArray(name).Sockets)
            {
                
                Console.Write("\t"+name+" slot " + socket.Key + ", ");
                if (name.Length >= 6)
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
            DisplayComponents(computer, "Cpu", ref count, binding);
            DisplayComponents(computer, "Ram", ref count, binding);
            DisplayComponents(computer, "Graphic", ref count, binding);
            DisplayComponents(computer, "Sound", ref count, binding);


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
                _displayController.GoToMainMenu();
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
                SelectCompatibleOptins(socket, "Cpu", computer.Motherboard.CpuSocketArray, _displayController.UnitOfWork.CpuRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptins(socket, "Ram", computer.Motherboard.RamSocketArray, _displayController.UnitOfWork.RamRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptins(socket, "Graphic", computer.Motherboard.GraphicSocketArray, _displayController.UnitOfWork.GraphicsRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());
                SelectCompatibleOptins(socket, "Sound", computer.Motherboard.SoundSocketArray, _displayController.UnitOfWork.SoundRepository.GetCompatible(computer.Motherboard).Cast<Item>().ToList());

                Console.ReadKey();
            }
         
        }

        public void SelectCompatibleOptins(ISocket socket, string type, ISocketArray socketArray, List<Item> compatible )
        {
            if (socket.Type == type)
            {
                var index = 1;
                Console.WriteLine("Please select the "+ type);
                
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



    }
}