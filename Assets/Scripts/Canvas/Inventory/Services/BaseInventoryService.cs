using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Inventory.Views;
using Interfaces.Cards;
using Serializable.Cards;
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

        private List<(byte, byte)> FillPositions { get; } = new List<(byte, byte)>();

        private (byte, byte) GridSize { get; set; }

        public void InitGridItems(GridLayoutGroup inventoryGrid)
        {
            for (byte i = 0; i < inventoryGrid.transform.childCount; i++)
            {
                var item = inventoryGrid.transform.GetChild(i);
                AddInventoryView(
                    (byte) (item.GetSiblingIndex() % inventoryGrid.constraintCount),
                    item.GetComponent<InventoryDroppableView>()
                );
            }

            var constraintCount = inventoryGrid.constraintCount;
            GridSize = ((byte, byte)) (constraintCount, inventoryGrid.transform.childCount / constraintCount);
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
            Debug.LogError($"Values.Count {GridSize.Item1} Keys.Count {GridSize.Item2}");
            var inventoryPos = sourceView.CardData.InventoryData.InventoryPos ?? TryFoundFreeInventoryPos();
            var rowIndex = inventoryPos.RowIndex;
            var colIndex = inventoryPos.ColIndex;
            AddFillPos(rowIndex, colIndex);
            sourceView.CardData.InventoryData.InventoryPos = inventoryPos;
            var position = InventoryViews[rowIndex][colIndex].transform.position;
            sourceView.OnSetPosition.Invoke(position);
        }

        private IInventoryPos TryFoundFreeInventoryPos()
        {
            for (byte i = 0; i < GridSize.Item1; i++)
            {
                for (byte j = 0; j < GridSize.Item2; j++)
                {
                    if (!HasFillThisPos(i, j))
                    {
                        Debug.LogError($"Founded row: {i} col: {j}");
                        return new InventoryPos
                        {
                            rowIndex = i,
                            colIndex = j
                        };
                    }
                }
            }

            Debug.LogError("Not Found any free pos");
            return new InventoryPos();
        }

        private void AddFillPos(byte rowIndex, byte colIndex)
        {
            if (!HasFillThisPos(rowIndex, colIndex))
                FillPositions.Add((rowIndex, colIndex));
        }

        private bool HasFillThisPos(byte rowIndex, byte colIndex)
        {
            return FillPositions.FindIndex(tuple => tuple.Item1 == rowIndex && tuple.Item2 == colIndex) != -1;
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