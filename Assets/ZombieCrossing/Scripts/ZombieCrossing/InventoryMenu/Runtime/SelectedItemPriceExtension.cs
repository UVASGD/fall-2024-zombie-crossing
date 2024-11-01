using UnityEngine.UIElements;
using ZombieCrossing.Inventory.Runtime;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    [System.Serializable] public class SelectedItemPriceExtension: SelectedInventoryItemExtension<Label>
    {
        protected override void HandleSelectedInventoryItem(Label label, InventoryItem inventoryItem)
        {
            label.text = inventoryItem.Price.ToString();
        }
    }
}