using Canvas.Inventory.Signals;
using Interfaces;
using Zenject;

namespace Canvas.Inventory.Services
{
    public class PersonalInventoryService : BaseInventoryService
    {
        private IPartyMember CurrentMember { get; set; }

        public PersonalInventoryService(SignalBus signalBus)
        {
            signalBus.Subscribe<SetCardToPersonalInventorySignal>(OnSetCardToPersonalInventory);
        }

        public void Init(IPartyMember partyMember)
        {
            CurrentMember = partyMember;
        }

        private void OnSetCardToPersonalInventory(SetCardToPersonalInventorySignal obj)
        {
            if (CurrentMember != null && obj.OwnerId != CurrentMember.Id)
                return;
            SetCardToInventory(obj.SourceView);
        }
    }
}