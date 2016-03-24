using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.Core.Managers
{
    public class InventoryManager
    {
        public List<Item> Inventory { get; private set; }

        public InventoryManager()
        {
            Inventory = new List<Item>();
        }

        public void AddInventory(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveInventory(Item item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
            }
        }

        public List<Item> GetPlayersInventory(int id)
        {
            return Inventory.Where(x => x.Owner == id).ToList();
        }
    }
}
