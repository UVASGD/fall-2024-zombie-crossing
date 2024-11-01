using System;
using UnityEngine;

namespace ZombieCrossing.Inventory.Runtime
{
    /// <summary>
    /// Channel over which to communicate interaction events with an <see cref="InventoryItem"/>.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(InventoryItemEventChannel), menuName = "ScriptableObjects/Inventory/Inventory Item Event Channel", order = 0)]
    public class InventoryItemEventChannel: ScriptableObject
    {
        /// <summary>
        /// Callback when the current inventory item is added.
        /// </summary>
        public event Action<InventoryItem> OnAddItem;

        /// <summary>
        /// Callback on the selected item changed.
        /// </summary>
        public event Action<InventoryItem> OnSetSelectedItem; 

        /// <summary>
        /// Raises the <see cref="OnAddItem"/> event. 
        /// </summary>
        /// <param name="inventoryItem">The new inventory inventoryItem.</param>
        public void RaiseOnAddItem(InventoryItem inventoryItem) => OnAddItem?.Invoke(inventoryItem); 
        
        /// <summary>
        /// Raises the <see cref="OnSetSelectedItem"/> event. 
        /// </summary>
        /// <param name="inventoryItem"></param>
        public void RaiseOnSetSelectedItem(InventoryItem inventoryItem) => OnSetSelectedItem?.Invoke(inventoryItem);
    }
}