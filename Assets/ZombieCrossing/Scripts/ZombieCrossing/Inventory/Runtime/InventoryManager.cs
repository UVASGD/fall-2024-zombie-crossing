using UnityEngine;

namespace ZombieCrossing.Inventory.Runtime
{
    public class InventoryManager: MonoBehaviour
    {
        [SerializeField] private InventoryItemEventChannel inventoryEventChannel;
        [SerializeField] private InventoryItemCollection inventory;

        private void OnEnable()
        {
            inventoryEventChannel.OnAddItem += AddItem;
        }

        private void OnDisable()
        {
            inventoryEventChannel.OnAddItem -= AddItem;
        }

        private void AddItem(InventoryItem newItem)
        {
            for (var i = 0; i < inventory.inventoryItems.Count; i++)
            {
                var item = inventory.inventoryItems[i];
                if (item.Name != newItem.Name) continue;
                item.Count += newItem.Count;
                return;
            }

            inventory.inventoryItems.Add(newItem);
        }
    }
}