using System.Collections.Generic;
using UnityEngine;

namespace ZombieCrossing.Inventory.Runtime
{
    /// <summary>
    /// Represents an inventory (whether that be in a shop or the players own inventory). 
    /// </summary>
    [CreateAssetMenu(fileName  = nameof(InventoryItemCollection), menuName = "ScriptableObjects/Inventory/Inventory")]
    public class InventoryItemCollection: ScriptableObject // I want to avoid just naming it "Inventory"
    {
        /// <summary>
        /// The list of inventory items. 
        /// </summary>
        public List<InventoryItem> inventoryItems;
    }
}