using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Interfaces.Cards;

namespace Canvas.Cards.Signals
{
    public class CreateResultCardsForActivitySignal
    {
        public List<IDraggableCardView> RunCardViews;
        public List<IBaseCard> ResultList;
    }
}