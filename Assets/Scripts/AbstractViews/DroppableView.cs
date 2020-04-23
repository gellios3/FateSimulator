using System;
using Canvas;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Views;
using Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AbstractViews
{
    /// <summary>
    /// Visible card on the table
    /// </summary>
    public class DroppableView : BaseView, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region Parameters

        public event Action CardDrop;

        [SerializeField] private Image bgImg;

        protected bool CanDropCard { get; private set; } = true;

        public IDraggableCardView DropCardCardView { get; set; }

        [SerializeField] protected ColorsPresetImage borderImg;

        #endregion

        public void SetDroppable(bool status)
        {
            CanDropCard = status;
            bgImg.raycastTarget = status;
        }

        /// <summary>
        /// Set status for border
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(Status status)
        {
            borderImg.SetStatus(status);
        }

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnDrop(PointerEventData eventData)
        {
            DropCardCardView = null;
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            DropCardCardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (DropCardCardView == null)
                return;
            DropCardCardView.SetPosition(transform.position);
            CardDrop?.Invoke();
            DropCardCardView.OnDropCard();
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer enter
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            SetStatus(Status.Highlighted);
            // Debug.LogError($"OnPointerEnter {eventData.pointerDrag}");   
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer exit
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            SetStatus(Status.Normal);
            var cardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (cardView != null)
            {
                // cardView.CanDraggable = true;
                // Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
            }
        }
    }
}