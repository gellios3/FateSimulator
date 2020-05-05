using System;
using Canvas;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Views;
using Enums;
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

        public event Action CardDrop;
        [SerializeField] private Image bgImg;
        private bool CanDropCard { get; set; } = true;
        public ushort DropCardId { get; set; }
        [SerializeField] protected ColorsPresetImage borderImg;
        [Inject] private CardActionsService CardActionsService { get; }

        #endregion

        /// <summary>
        ///  Set droppable
        /// </summary>
        /// <param name="status"></param>
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
            DropCardId = 0;
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            var dropCardCardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (dropCardCardView == null)
                return;
            DropCardId = dropCardCardView.CardId;
            CardActionsService.SetCardPositionById(DropCardId, transform.position);
            CardDrop?.Invoke();
            CardActionsService.OnDropById(DropCardId);
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
    }
}