using UnityEngine;
using Zenject;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Draggable card service
    /// </summary>
    public class DraggableCardService
    {
        #region Parameters

        private bool CanDraggable { get; set; } = true;
        public bool HasDrop { get; private set; }
        private bool HasOutArea { get; set; }
        public bool HasStartDrag { get; private set; }
        public Vector3 TempPosition { get; private set; }

        #endregion

        /// <summary>
        /// Can begin drag
        /// </summary>
        /// <returns></returns>
        public bool CanBeginDrag()
        {
            if (!CanDraggable)
                return false;
            HasDrop = false;
            HasStartDrag = true;
            return true;
        }

        /// <summary>
        /// Can end drag
        /// </summary>
        /// <returns></returns>
        public bool CanEndDrag()
        {
            if (HasDrop)
                return false;
            if (!HasOutArea)
                CanDraggable = true;
            return true;
        }

        /// <summary>
        /// Drag card
        /// </summary>
        public bool CanDragCard()
        {
            return CanDraggable && Camera.main != null;
        }

        /// <summary>
        /// Drop card
        /// </summary>
        public void DropCard()
        {
            HasDrop = true;
        }

        /// <summary>
        /// End drag
        /// </summary>
        public bool HasOutDrag()
        {
            HasStartDrag = false;
            return HasOutArea;
        }

        /// <summary>
        /// Drop on activity
        /// </summary>
        /// <param name="value"></param>
        public void OnDropOnActivity(bool value)
        {
            CanDraggable = !value;
        }

        /// <summary>
        /// Return back
        /// </summary>
        public void ReturnBack()
        {
            HasOutArea = false;
        }

        /// <summary>
        /// Set out of draggable area
        /// </summary>
        /// <param name="value"></param>
        public void SetOutArea(bool value)
        {
            HasOutArea = value;
            CanDraggable = !value;
        }

        /// <summary>
        /// Set temp position
        /// </summary>
        /// <param name="pos"></param>
        public void SetTempPos(Vector3 pos)
        {
            TempPosition = pos;
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
            var xy = new Plane(Vector3.down, new Vector3(0, 0, z));
            xy.Raycast(ray, out var distance);
            return ray.GetPoint(distance);
        }
    }
}