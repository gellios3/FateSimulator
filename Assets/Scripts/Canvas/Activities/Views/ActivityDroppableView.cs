using AbstractViews;
using Canvas.Cards.Services;
using Canvas.Popups.Signals.Activity;
using Enums;
using UnityEngine.EventSystems;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity droppable view
    /// </summary>
    public class ActivityDroppableView : DroppableView, IPointerDownHandler
    {
        [Inject] private CardActionsService CardActionsService { get; }

        [Inject] private SignalBus SignalBus { get; }

        /// <summary>
        /// Return drop card
        /// </summary>
        public void ReturnDropCard()
        {
            if (DropCard == null)
                return;
            borderImg.SetStatus(Status.Normal);
            CardActionsService.ShowCard(DropCardCardView);
            CardActionsService.ReturnBack(DropCardCardView);
            DropCard = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SignalBus.Fire(new TryFindStartActivityCardsSignal());
        }
    }
}