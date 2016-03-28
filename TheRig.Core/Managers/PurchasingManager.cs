
using System;
using TheRig.Models.Components;

namespace TheRig.Core.Managers
{
    public class PurchasingManager
    {

        public readonly FinanceManager _financeManager;
        public readonly InventoryManager _inventoryManager;
        

        public PurchasingManager(FinanceManager financeManager, InventoryManager inventoryManager)
        {
            _financeManager = financeManager;
            _inventoryManager = inventoryManager;
        }


        public void PurchaseItem(Item item, int qty, DateTime date)
        {
            _financeManager.DebitFunds(new Transaction { DateCreated = date, Name = item.Name, Quantity = qty, Value = (item.Price * qty) });
            for (int x = 0; x < qty; x++)
            {
                _inventoryManager.AddInventory(item);
            }
        }


    }
}
