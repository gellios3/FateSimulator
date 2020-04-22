using AbstractViews;
using Canvas.Cards.Views;
using UnityEngine.EventSystems;

namespace Canvas
{
    public class NonDraggableAreaView : BaseView, IPointerEnterHandler, IPointerExitHandler
    {
        private DraggableView tempDraggable;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (draggableView == null) 
                return;
            draggableView.CanDraggable = false;
            draggableView.HasOutArea = true;
            tempDraggable = draggableView;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (tempDraggable != null)
                tempDraggable.CanDraggable = true;
        }
    }
}
