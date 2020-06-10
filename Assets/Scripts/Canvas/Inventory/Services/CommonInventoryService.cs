using System.Collections.Generic;
using Canvas.Cards.Signals;
using Canvas.Inventory.Views;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Inventory.Services
{
    public class CommonInventoryService
    {
        private Dictionary<byte, List<InventoryDroppableView>> InventoryViews { get; } =
            new Dictionary<byte, List<InventoryDroppableView>>();

        public CommonInventoryService(SignalBus signalBus)
        {
            signalBus.Subscribe<SetCardToCommonInventorySignal>(SetCommonCards);
        }

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
        /// Set common cards 
        /// </summary>
        /// <param name="signal"></param>
        private void SetCommonCards(SetCardToCommonInventorySignal signal)
        {
            var sourceView = signal.SourceView;
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