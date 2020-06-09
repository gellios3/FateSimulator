using Canvas.Cards.Services;
using Canvas.Cards.Views;
using UnityEngine.EventSystems;
using Zenject;

namespace AbstractViews
{
    public class NonDraggableAreaView : BaseView, IPointerEnterHandler, IPointerExitHandler
    {
        private ushort tempCardId;

        [Inject] private CardActionsService CardActionsService { get; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (draggableView == null)
                return;
            tempCardId = draggableView.CardData.BaseCard.Id;
            CardActionsService.OnOutAreaById(tempCardId, true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CardActionsService.OnOutAreaById(tempCardId, false);
        }
    }
}