using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Models;
using TheRig.Models.Components;
using TheRig.Models.Components.Sockets;
using TheRig.UI.Controller;
using TheRig.UI.Helper;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus;

namespace TheRig.UI.Pages
{
    public class SelectMenuComponentsPage : IPage
    {
        private readonly GameController _gameController;
        private Blueprint _blueprint;

        public SelectMenuComponentsPage(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Title()
        {
            Console.Clear();
            Console.WriteLine("Blueprint - select components");
            Console.WriteLine("----------------------------------");
        }

        public void Draw()
        {
            
            SelectBlueprint();
            Console.WriteLine("");
            ShowBlueprint();

            MenuOptions();

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                DisplayAndSelectBlueprint();
            }
            if (key.Key == ConsoleKey.B)
            {
                SelectMotherboard();
            }
            if (key.Key == ConsoleKey.C)
            {
                SelectCpu();
            }
            if (key.Key == ConsoleKey.D)
            {
                SelectRam();
            }
            if (key.Key == ConsoleKey.E)
            {
                SelectGraphics();
            }
            if (key.Key == ConsoleKey.F)
            {
                SelectSound();
            }

            if (key.Key == ConsoleKey.X)
            {
                Back();
            }
        }

        private void ShowBlueprint()
        {
            var cost = _blueprint.Computer.Motherboard.Price;

            Console.WriteLine("Motherboard :\t\t" + _blueprint.Computer.Motherboard.Name + "\t£" + _blueprint.Computer.Motherboard.Price);
            Console.WriteLine("-Components----------------");
            ViewSockets(_blueprint.Computer.Motherboard.CpuSocketArray.Sockets, ref cost);
            ViewSockets(_blueprint.Computer.Motherboard.RamSocketArray.Sockets, ref cost);
            ViewSockets(_blueprint.Computer.Motherboard.GraphicSocketArray.Sockets, ref cost);
            ViewSockets(_blueprint.Computer.Motherboard.SoundSocketArray.Sockets, ref cost);
            Console.WriteLine();
            Console.WriteLine("Cost: " + cost);
            Console.WriteLine();
        }

        private void ViewSockets(Dictionary<int, ISocket> sockets, ref decimal  cost )
        {
            foreach (var socket in sockets)
            {
                string tabs = "";
                if (socket.Value.Type == SocketType.Graphics)
                {
                    tabs += "\t";
                }
                else
                {
                    tabs += "\t\t";
                }
                if (socket.Value.IsInstalled)
                {
                    Console.WriteLine("\t"+socket.Value.Type + " Socket " + socket.Key + ":"+tabs + socket.Value.Item.Name + tabs+ "£"+ socket.Value.Item.Price);
                    cost += socket.Value.Item.Price;
                }
                else
                {
                    Console.WriteLine("\t" + socket.Value.Type+" Socket " + socket.Key + ":"+ tabs+"Not set.");
                }
            }
        }

        private void SelectCpu()
        {
            DisplayHelper helper = new DisplayHelper();
            var item = helper.SelectableList(_gameController.GameManager.UnitOfWork.CpuRepository.GetCompatible(_blueprint.Computer.Motherboard).Cast<Item>().ToList());
            _blueprint.Computer.Motherboard.CpuSocketArray.Add(item);
        }
        private void SelectSound()
        {
            DisplayHelper helper = new DisplayHelper();
            var item = helper.SelectableList(_gameController.GameManager.UnitOfWork.SoundRepository.GetCompatible(_blueprint.Computer.Motherboard).Cast<Item>().ToList());
            _blueprint.Computer.Motherboard.SoundSocketArray.Add(item);
        }

        private void SelectGraphics()
        {
            DisplayHelper helper = new DisplayHelper();
            var item = helper.SelectableList(_gameController.GameManager.UnitOfWork.GraphicsRepository.GetCompatible(_blueprint.Computer.Motherboard).Cast<Item>().ToList());
            _blueprint.Computer.Motherboard.GraphicSocketArray.Add(item);
        }

        private void SelectRam()
        {
            DisplayHelper helper = new DisplayHelper();
            var item = helper.SelectableList(_gameController.GameManager.UnitOfWork.RamRepository.GetCompatible(_blueprint.Computer.Motherboard).Cast<Item>().ToList());
            _blueprint.Computer.Motherboard.RamSocketArray.Add(item);
        }

        private void SelectMotherboard()
        {
            if (_blueprint.Computer.Motherboard.Name == "Not set.")
            {
                Console.WriteLine("You must select a motherboard first.");
                DisplayHelper helper = new DisplayHelper();
                var item =helper.SelectableList(_gameController.GameManager.UnitOfWork.MotherboardRepository.Find().Cast<Item>().ToList());
                _blueprint.Computer.Motherboard = (Motherboard)item;
            }
            
        }

        private void DisplayAndSelectBlueprint()
        {
            if (_gameController.GameManager.GameState.Managers.BlueprintManager.GetPlayersBlueprints(1).Any())
            {
                bool repeat = true;
                do
                {
                    Title();

                    Console.WriteLine("please select a blue print.");
                    var count = 1;
                    foreach (var bp in _gameController.GameManager.GameState.Managers.BlueprintManager.GetPlayersBlueprints(1))
                    {
                        Console.WriteLine(count + ", " + bp.Name);
                        count++;
                    }
                    var selectedVal = Console.ReadLine();
                    var val = 0;
                    if (int.TryParse(selectedVal, out val))
                    {
                        repeat = false;
                        if (val > 0 && val <= _gameController.GameManager.GameState.Managers.BlueprintManager.GetPlayersBlueprints(1).Count())
                        {
                            _blueprint = _gameController.Player.BlueprintManager.SelectedBlueprint = _gameController.Player.BlueprintManager.Blueprints.ElementAt(val - 1);
                        }
                        else
                        {
                            repeat = true;
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        repeat = true;
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                    }
                } while (repeat);
            }
            else
            {
                Console.WriteLine("You have no blueprints, you must build one first.");
            }
        
        }

        private void SelectBlueprint()
        {
            _blueprint = _gameController.Player.BlueprintManager.SelectedBlueprint;
            if (_blueprint != null)
            {
                Title();
                Console.WriteLine("Current Blueprint: " + _blueprint.Name);
            }
            else
            {
                DisplayAndSelectBlueprint();
            }
        }

        public void MenuOptions()
        {
            Console.WriteLine("A: Change the selected blueprint.");
            Console.WriteLine("B: Select Motherboard.");
            Console.WriteLine("C: Select Cpu.");
            Console.WriteLine("D: Select Ram.");
            Console.WriteLine("E: Select Graphics.");
            Console.WriteLine("F: Select Sound.");
            Console.WriteLine("X: Go back to previous screen.");
        }

        public void Back()
        {
            var page = (AssemblyMenuPage)_gameController.GamePages.Pages["AssemblyMenu"];
            _gameController.GamePages.ActivePage = page;
        }
    }
}
