using System;
using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using ZombieCrossing.Inventory.Runtime;

namespace ZombieCrossing.InventoryMenu.Runtime
{
    public abstract class SelectedInventoryItemExtension<T>: MenuEventExtension<T> where T: VisualElement
    {
        [field: SerializeField] public override UQueryBuilderSerializable Query { get; protected set; }
        [SerializeField] private InventoryItemEventChannel inventoryItemEventChannel; 
        
        protected override Action OnAttach(T visualElement, PlayerInput playerInput)
        {
            inventoryItemEventChannel.OnSetSelectedItem += SetDescription;
            return () => inventoryItemEventChannel.OnSetSelectedItem -= SetDescription;
            void SetDescription(InventoryItem inventoryItem) => HandleSelectedInventoryItem(visualElement, inventoryItem);
        }

        /// <summary>
        /// Handles callback on <see cref="InventoryItemEventChannel.OnSetSelectedItem"/>. 
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/> to modify.</param>
        /// <param name="inventoryItem">The selected <see cref="InventoryItem"/>.</param>
        protected abstract void HandleSelectedInventoryItem(T visualElement, InventoryItem inventoryItem);
    }
}