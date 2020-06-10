using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Enums;
using Interfaces.Cards;
using Zenject;

namespace Services
{
    public class CardDataService
    {
        [Inject] private List<ICardData> CardDataList { get; }

        [Inject] private SignalBus SignalBus { get; }
        
        public List<IDraggableCardView> CardViews { get; }

        public IEnumerable<IDraggableCardView> GetCommonCards()
        {
            return CardViews.FindAll(view => view.CardData.InventoryData.InventoryType == InventoryType.Common);
        }
    }
}