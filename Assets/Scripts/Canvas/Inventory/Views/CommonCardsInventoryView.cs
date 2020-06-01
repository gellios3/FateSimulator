using AbstractViews;
using Canvas.Inventory.Services;
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
        }
    }
}