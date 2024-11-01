using UnityEngine.UIElements;
using ZombieCrossing.Inventory.Runtime;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    [System.Serializable] public class SelectedItemNameExtension: SelectedInventoryItemExtension<Label>
    {
        protected override void HandleSelectedInventoryItem(Label label, InventoryItem inventoryItem)
        {
            label.text = inventoryItem.Name;
        }
    }
}