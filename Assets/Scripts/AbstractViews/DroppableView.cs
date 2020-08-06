using System;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Views;
using Enums;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace AbstractViews
{
    /// <summary>
    /// Visible card on the table
    /// </summary>
    public class DroppableView : BaseView, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region Parameters

        public event Action<IDraggableCardView> CardDrop;
        public ICardData DropCard { get; set; }

        [SerializeField] private Image bgImg;
        [SerializeField] protected ColorsPresetImageView borderImg;

        protected IDraggableCardView DropCardCardView; 
        [Inject] private CardActionsService CardActionsService { get; }
        private bool CanDropCard { get; set; } = true;

        #endregion

        /// <summary>
        ///  Set droppable
        /// </summary>
        /// <param name="status"></param>
        public void SetDroppable(bool status)
        {
            CanDropCard = status;
            // bgImg.raycastTarget = status;
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
            DropCard = null;
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            DropCardCardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (DropCardCardView == null)
                return;
            DropCard = DropCardCardView.CardData;
            OnDrop();
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
            // var cardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            // if (cardView != null)
            // {
            //     // cardView.CanDraggable = true;
            //     // Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
            // }
        }

        protected void OnDrop()
        {
            CardActionsService.SetCardPosition(DropCardCardView, transform.position);
            CardDrop?.Invoke(DropCardCardView);
            CardActionsService.CallOnDrop(DropCardCardView);
        }
    }
}