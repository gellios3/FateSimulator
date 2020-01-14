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
            var pos = GetWorldPositionOnPlane(eventData.position, -1);
            transform.position = pos;
        }

        /// <summary>
        /// Get World position on plane
        /// </summary>
        /// <param name="screenPosition"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
        {
            if (Camera.main == null)
                return Vector3.zero;
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            var xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
            xy.Raycast(ray, out var distance);
            return ray.GetPoint(distance);
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
            
            var position = transform.position;
            position.z = -3;
            transform.position = position;
        }
    }
}