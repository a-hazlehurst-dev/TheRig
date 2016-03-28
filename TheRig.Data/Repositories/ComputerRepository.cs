using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.UI.Controller
{
    public class ComputerRepository
    {
        private List<Computer> _computers;

        public ComputerRepository()
        {
            _computers = new List<Computer>();
        }
        public Computer GetComputer(string name)
        {
            var computer = _computers.SingleOrDefault(x => x.Name == name);
            if (computer==null)
            {
                computer = new Computer {Name = name};
                AddComputer(computer);
            }
            return computer;
        }

        public List<Computer> GetAll()
        {
            return _computers;
        }

        public void AddComputer(Computer computer)
        {
            _computers.Add(computer);
        }
    }
}