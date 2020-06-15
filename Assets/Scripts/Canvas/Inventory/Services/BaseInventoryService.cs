using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Inventory.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas.Inventory.Services
{
    /// <summary>
    /// Base inventory service
    /// </summary>
    public abstract class BaseInventoryService
    {
        private Dictionary<byte, List<InventoryDroppableView>> InventoryViews { get; } =
            new Dictionary<byte, List<InventoryDroppableView>>();
        
        public void InitGridItems(GridLayoutGroup inventoryGrid)
        {
            for (var i = 0; i < inventoryGrid.transform.childCount; i++)
            {
                var item = inventoryGrid.transform.GetChild(i);
                AddInventoryView(
                    (byte) (item.GetSiblingIndex() % inventoryGrid.constraintCount),
                    item.GetComponent<InventoryDroppableView>()
                );
            }
        }

        public void SetDroppableStatusForInventory(bool hasDroppable)
        {
            foreach (var pair in InventoryViews)
            {
                foreach (var view in pair.Value)
                {
                    view.SetDroppable(hasDroppable);
                }
            }
        }

        /// <summary>
        /// Set card to Inventory
        /// </summary>
        /// <param name="sourceView"></param>
        protected void SetCardToInventory(IDraggableCardView sourceView)
        {
            if (sourceView.CardData.InventoryData == null || InventoryViews.Count <= 0) 
                return;
            var rowIndex = sourceView.CardData.InventoryData.InventoryPos.RowIndex;
            var colIndex = sourceView.CardData.InventoryData.InventoryPos.ColIndex;
            var position = InventoryViews[rowIndex][colIndex].transform.position;
            sourceView.OnSetPosition.Invoke(position);
        }
        
        /// <summary>
        /// Add Inventory view
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="droppableView"></param>
        private void AddInventoryView(byte rowIndex, InventoryDroppableView droppableView)
        {
            if (!InventoryViews.ContainsKey(rowIndex))
            {
                InventoryViews.Add(rowIndex, new List<InventoryDroppableView>());
            }

            InventoryViews[rowIndex].Add(droppableView);
        }
    }
}