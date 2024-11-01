using UnityEngine;

namespace ZombieCrossing.Inventory.Runtime
{
    /// <summary>
    /// A single item (e.g. inventory item, collectible, etc.). 
    /// </summary>
    [System.Serializable]
    public struct InventoryItem
    {
        /// <summary>
        /// The name that represents this item. Also used as an id. 
        /// </summary>
        [field: SerializeField] public string Name { get; set; }

        /// <summary>
        /// The description for this item in UI.
        /// </summary>
        [field: SerializeField] public string Description { get; set; }

        /// <summary>
        /// The icon that represents this item in UI.
        /// </summary>
        [field: SerializeField] public Sprite Icon { get; set; }

        /// <summary>
        /// The amount of this item. 
        /// </summary>
        [field: SerializeField] public int Count { get; set; }
        
        /// <summary>
        /// The price of this item. 
        /// </summary>
        [field: SerializeField] public int Price { get; set; }
    }
}