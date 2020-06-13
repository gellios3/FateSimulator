using Canvas.Cards.Interfaces;

namespace Canvas.Inventory.Signals
{
    public class SetCardToPersonalInventorySignal
    {
        public ushort OwnerId;
        public IDraggableCardView SourceView;
    }
}