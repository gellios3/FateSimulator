using AbstractViews;
using Canvas.Cards.Signals;
using Canvas.Inventory.Services;
using Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Inventory.Views
{
    public class CommonCardsInventoryView : BaseView
    {
        [SerializeField] private GridLayoutGroup inventoryGrid;
        
        [Inject] private CommonInventoryService CommonInventoryService { get; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            CommonInventoryService.InitGridItems(inventoryGrid);
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
        }
        
        private void OnStartDragCard(StartDragCardSignal obj)
        {
            CommonInventoryService.SetDroppableStatusForInventory(
                obj.DraggableCardView.CardData.InventoryData.InventoryType == InventoryType.Common
            );
        }

        private void OnEndDragCard(EndDragCardSignal obj)
        {
            CommonInventoryService.SetDroppableStatusForInventory(true);
        }
    }
}