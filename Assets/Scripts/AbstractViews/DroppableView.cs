using UnityEngine;
using UnityEngine.EventSystems;

namespace AbstractViews
{
    public sealed class DroppableView : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            Debug.LogError($"DroppableView {eventData.pointerDrag}"); 
            eventData.pointerDrag.transform.SetAsLastSibling();
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer enter
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
//            Debug.LogError($"OnPointerEnter {eventData.pointerDrag}");   
                  
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer exit
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
//            Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
        }
    }
}