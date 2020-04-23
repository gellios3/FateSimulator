using AbstractViews;
using UnityEngine.EventSystems;

namespace Canvas.Cards.Views
{
    public abstract class BaseDraggableCardView : BaseView, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public abstract void OnBeginDrag(PointerEventData eventData);

        public abstract void OnDrag(PointerEventData eventData);

        public abstract void OnEndDrag(PointerEventData eventData);
    }
}