using System.Collections.Generic;
using AbstractViews;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Canvas.Inventory.Views
{
    public class AllPersonalCardsView : BaseView
    {
        [SerializeField] private List<PersonalInventoryView> inventoryViews;
        
        [Inject] private List<IPartyMember> PartyMembers { get; }

        private void Start()
        {
            for (var i = 0; i < PartyMembers.Count; i++)
            {
                inventoryViews[i].Init(PartyMembers[i]);
            }
        }
    }
}