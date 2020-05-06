using AbstractViews;
using Canvas.Cards.Services;
using Enums;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity droppable view
    /// </summary>
    public class ActivityDroppableView : DroppableView
    {
        [Inject] private CardActionsService CardActionsService { get; }
        
        /// <summary>
        /// Return drop card
        /// </summary>
        public void ReturnDropCard( )
        {
            if (DropCardId == 0)
                return;
            borderImg.SetStatus(Status.Normal);
            CardActionsService.ShowCard(DropCardCardView);
            CardActionsService.ReturnBack(DropCardCardView);
            DropCardId = 0;
        }
    }
}