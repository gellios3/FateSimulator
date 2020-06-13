using AbstractViews;
using Canvas.Inventory.Services;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Inventory.Views
{
    public class PersonalInventoryView : BaseView
    {
        [SerializeField] private GridLayoutGroup inventoryGrid;
        
        [Inject] private PersonalInventoryService PersonalInventoryService { get; }
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            Hide();
            
        }
        public void Init(IPartyMember partyMember)
        {
            Show();
            PersonalInventoryService.Init(partyMember);
            PersonalInventoryService.InitGridItems(inventoryGrid);
        }
    }
}