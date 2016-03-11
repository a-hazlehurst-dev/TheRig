using System.Collections.Generic;
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
    }
}
