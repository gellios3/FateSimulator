using Canvas.Cards.Views;
using UnityEngine;

namespace Canvas.Cards.Services
{
    public class DraggableCardService
    {
        #region Parameters
        private bool CanDraggable { get; set; } = true;
        private bool HasDrop { get; set; }
        private bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        public bool HasStartDrag { get; private set; }
        public Vector3 TempPosition { get; private set; }
        private DraggableCardView SourceView { get; set; }
        #endregion

        public void Init(DraggableCardView draggable)
        {
            SourceView = draggable;
        }

        public bool CanBeginDrag()
        {
            if (!CanDraggable)
                return false;
            HasDrop = false;
            HasStartDrag = true;
            return true;
        }

        public bool CanEndDrag()
        {
            if (HasDrop)
                return false;
            if (!HasOutArea)
                CanDraggable = true;
            return true;
        }

        public void DragCard(Vector3 pos)
        {
            if (!(CanDraggable && Camera.main != null))
                return;
            SourceView.SetPosition(GetWorldPositionOnPlane(pos, -1));
        }
        
        public void DropCard()
        {
            HasDrop = true;
            HasSetInInventory = true;
        }

        public void EndDrag()
        {
            HasStartDrag = false;

            if (HasOutArea)
            {
                SourceView.ReturnBack(HasSetInInventory);
                return;
            }

            HasSetInInventory = false;
        }

        public void OnDropOnActivity(bool value)
        {
            CanDraggable = !value;
        }

        public void ReturnBack(bool value)
        {
            HasOutArea = false;
            HasSetInInventory = value;
        }
        
        public void SetOutArea(bool value)
        {
            HasOutArea = value;
            CanDraggable = !value;
        }
        
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