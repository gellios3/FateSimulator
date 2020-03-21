using AbstractViews;
using UnityEngine;
using UnityEngine.EventSystems;

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

        Debug.LogError("On Enter in area");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tempDraggable != null)
            tempDraggable.CanDraggable = true;
    }
}