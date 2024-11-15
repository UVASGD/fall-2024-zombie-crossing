using UnityEngine;
using UnityEngine.UIElements;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    /// <summary>
    /// Represents a single item. 
    /// </summary>
    [System.Serializable]
    public struct InventoryItemAsset
    {
        /// <summary>
        /// The <see cref="VisualTreeAsset"/> used to represent the item. 
        /// </summary>
        [field: SerializeField] public VisualTreeAsset VisualTreeAsset { get; private set; }
        
        /// <summary>
        /// The name of the image that represents the item within the <see cref="VisualTreeAsset"/>. 
        /// </summary>
        [field: SerializeField] 
        public string ImageName { get; private set; }
        
        /// <summary>
        /// The name of the label that represents the name of an item within the <see cref="VisualTreeAsset"/>. 
        /// </summary>
        [field: SerializeField] 
        public string NameLabelName { get; private set; }
        
        /// <summary>
        /// The name of the label that represents the count of an item within the <see cref="VisualTreeAsset"/>. 
        /// </summary>
        [field: SerializeField] 
        public string CountLabelName { get; private set; }
        
        /// <summary>
        /// The name of the label that represents the price of an item within the <see cref="VisualTreeAsset"/>. 
        /// </summary>
        [field: SerializeField] 
        public string PriceLabelName { get; private set; }
    }
}