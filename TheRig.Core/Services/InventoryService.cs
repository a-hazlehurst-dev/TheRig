using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.Core.Services
{
    public class InventoryService
    {
        public List<Item> Inventory { get; private set; }

        public InventoryService()
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
