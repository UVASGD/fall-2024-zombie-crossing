using UnityEngine;
using ZombieCrossing.CommandPattern.Runtime;

namespace ZombieCrossing.Inventory.Runtime
{
    
    /// <summary>
    /// Replaces the items in one inventory with that of another.
    /// </summary>
    /// <remarks>
    /// For example, since the a <see cref="ZombieCrossing.InventoryMenu.Runtime.PopulateItemsExtension"/>
    /// can only reference one, immutable scriptable object, you have to copy the inventory that you want to display
    /// to the one that the menu references. 
    /// </remarks>
    public class CopyInventoryItemsCommand: MonoBehaviour, ICommand
    {
        [SerializeField] private InventoryItemCollection source;
        [SerializeField] private InventoryItemCollection destination;
        
        public void Execute()
        {
            destination.inventoryItems = source.inventoryItems;
        }
    }
}