using UnityEngine;
using UnityEngine.EventSystems;

namespace AbstractViews
{
    public sealed class DraggableView : BaseItem, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool CanDraggable { private get; set; } = true;

        public bool CanDroppable { get; } = true;

        /// <inheritdoc />
        /// <summary>
        /// On begin drag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!CanDraggable)
                return;
            
            transform.SetAsFirstSibling();

            HasDraggable = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// On drag card
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if (!CanDraggable)
                return;

            if (Camera.main == null) 
                return;

            transform.position = eventData.position;
            
        }

        /// <inheritdoc />
        /// <summary>
        /// On End drag card
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!CanDraggable)
                return;

            HasDraggable = false;
        }
    }
}