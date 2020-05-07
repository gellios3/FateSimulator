using System.Collections.Generic;
using Canvas.Cards.Interfaces;

namespace Canvas.Popups.Signals.Activity
{
    public class StartActivitySignal
    {
        public ushort ActivityId;
        public List<IDraggableCardView> DropCardViews;
    }
}