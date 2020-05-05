using Canvas.Cards.Views;
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
        private bool HasDrop { get; set; }
        private bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        public bool HasStartDrag { get; private set; }
        public Vector3 TempPosition { get; private set; }
        private ushort CardId { get; set; }

        [Inject] private CardActionsService CardActionsService { get; }

        #endregion

        public void Init(ushort draggableId)
        {
            CardId = draggableId;
        }

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
        /// <param name="pos"></param>
        public void DragCard(Vector3 pos)
        {
            if (!(CanDraggable && Camera.main != null))
                return;
            CardActionsService.SetCardPositionById(CardId, GetWorldPositionOnPlane(pos, -1));
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
        public void EndDrag()
        {
            HasStartDrag = false;

            if (HasOutArea)
            {
                CardActionsService.ReturnBackById(CardId);
                return;
            }

            HasSetInInventory = false;
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
        /// <param name="value"></param>
        public void ReturnBack(bool value)
        {
            HasOutArea = false;
            HasSetInInventory = value;
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
        private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
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