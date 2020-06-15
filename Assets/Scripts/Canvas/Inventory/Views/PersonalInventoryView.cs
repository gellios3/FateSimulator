using AbstractViews;
using Canvas.Cards.Signals;
using Canvas.Inventory.Services;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Inventory.Views
{
    public class PersonalInventoryView : BaseView
    {
        [SerializeField] private GridLayoutGroup inventoryGrid;
        [SerializeField] private TextMeshProUGUI title;

        [Inject] private PersonalInventoryService PersonalInventoryService { get; }

        private IPartyMember CurrentMember { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            Hide();
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
        }
        
        public void Init(IPartyMember partyMember)
        {
            CurrentMember = partyMember;
            title.text = partyMember.Name;
            Show();
            PersonalInventoryService.Init(partyMember);
            PersonalInventoryService.InitGridItems(inventoryGrid);
        }
        
        private void OnStartDragCard(StartDragCardSignal obj)
        {
            if (!HasShow)
                return;
            PersonalInventoryService.SetDroppableStatusForInventory(
                obj.DraggableCardView.CardData.InventoryData.OwnerId == CurrentMember.Id
            );
        }
        
        private void OnEndDragCard(EndDragCardSignal obj)
        {
            if (!HasShow)
                return;
            PersonalInventoryService.SetDroppableStatusForInventory(true);
        }
    }
}