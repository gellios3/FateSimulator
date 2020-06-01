using System.Collections.Generic;
using Canvas.Inventory.Views;
using UnityEngine.UI;

namespace Canvas.Inventory.Services
{
    public class CommonInventoryService
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