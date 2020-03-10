using UnityEngine;
using UnityEngine.EventSystems;

namespace AbstractViews
{
    public sealed class DraggableView : BaseItem, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool CanDraggable { private get; set; } = true;

        public bool CanDroppable { get; } = true;

        [SerializeField] private GameObject topCard;

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
            topCard.SetActive(true);
        }

        /// <inheritdoc />
        /// <summary>
        /// On drag card
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if (!CanDraggable || Camera.main == null)
                return;
            var pos = GetWorldPositionOnPlane(eventData.position, -1);
            transform.position = pos;
            topCard.transform.position = pos;
        }

        /// <summary>
        /// Get World position on plane
        /// </summary>
        /// <param name="screenPosition"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private static Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
        {
            if (Camera.main == null)
                return Vector3.zero;
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            var xy = new Plane(Vector3.down, new Vector3(0, 0, z));
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
            position.y = 3;
            transform.position = position;
            topCard.transform.position = position;
            // topCard.SetActive(false);
        }
    }
}