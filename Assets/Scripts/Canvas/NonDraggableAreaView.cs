using AbstractViews;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Views;
using UnityEngine.EventSystems;

namespace Canvas
{
    public class NonDraggableAreaView : BaseView, IPointerEnterHandler, IPointerExitHandler
    {
        private IDraggableCardView tempDraggableCard;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (draggableView == null)
                return;
            // draggableView.CanDraggable?.Invoke(false);
            draggableView.OutArea?.Invoke(true);
            tempDraggableCard = draggableView;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tempDraggableCard?.OutArea?.Invoke(false);
            // tempDraggableCard?.CanDraggable?.Invoke(true);
        }
    }
}