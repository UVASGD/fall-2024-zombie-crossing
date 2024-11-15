using System;
using System.Collections.Generic;
using System.Linq;
using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using ZombieCrossing.Inventory.Runtime;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    /// <summary>
    /// Displays the inventory UI
    /// </summary>
    [Serializable] public class PopulateItemsExtension: MenuEventExtension<ListView>
    {
        [field: SerializeField] public override UQueryBuilderSerializable Query { get; protected set; }
        [SerializeField] private InventoryItemEventChannel inventoryItemEventChannel; 
        [SerializeField] private InventoryItemAsset inventoryItemAsset;
        [SerializeField] private InventoryItemCollection inventoryItemCollection;
        
        protected override Action OnAttach(ListView listView, PlayerInput playerInput)
        {
            listView.Clear();
            
            listView.selectionType = SelectionType.Single;
            listView.itemsSource = inventoryItemCollection.inventoryItems;
            listView.itemTemplate = inventoryItemAsset.VisualTreeAsset;
            listView.bindItem = BindItem;
            
            listView.RefreshItems();

            listView.selectionChanged += OnSelectionChanged; 
            return () =>
            {
                listView.selectionChanged -= OnSelectionChanged;
            }; 
        }
        
        private void BindItem(VisualElement itemVisualElement, int index)
        {
            var item = inventoryItemCollection.inventoryItems[index];
            
            itemVisualElement.Q<VisualElement>(inventoryItemAsset.ImageName).style.backgroundImage = new StyleBackground(item.Icon);
            itemVisualElement.Q<Label>(inventoryItemAsset.NameLabelName).text = item.Name;
            itemVisualElement.Q<Label>(inventoryItemAsset.CountLabelName).text = item.Count.ToString();
            itemVisualElement.Q<Label>(inventoryItemAsset.PriceLabelName).text = item.Price.ToString();
        }
        
        private void OnSelectionChanged(IEnumerable<object> enumerable)
        {
            var objects = enumerable as object[] ?? enumerable.ToArray();
            var selectedItem = objects.First() is InventoryItem inventoryItem ? inventoryItem : default;
            inventoryItemEventChannel.RaiseOnSetSelectedItem(selectedItem);
        }
    }
}