using UnityEngine.UIElements;
using ZombieCrossing.Inventory.Runtime;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    [System.Serializable] public class SelectedItemImageExtension: SelectedInventoryItemExtension<VisualElement>
    {
        protected override void HandleSelectedInventoryItem(VisualElement visualElement, InventoryItem inventoryItem)
        {
            visualElement.style.backgroundImage = new StyleBackground(inventoryItem.Icon);
        }
    }
}