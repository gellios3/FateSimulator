using AbstractViews;
using Canvas.Cards.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Canvas
{
    public class DraggableAreaView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private DraggableView tempDraggable;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (draggableView != null)
            {
                draggableView.CanDraggable = false;
                draggableView.HasOutArea = true;
                // draggableView.CallEndDrag();
            
                tempDraggable = draggableView;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (tempDraggable != null)
                tempDraggable.CanDraggable = true;
        }
    }
}
