using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Canvas.Cards.Views
{
    public class DroppableCardView : BaseView, IDropHandler
    {
        private StackCountView StackCountView { get; set; }
        private List<IDraggableCardView> DropCards { get; } = new List<IDraggableCardView>();
        private ICardData sourceCard;
        private bool CanDropCard { get; set; }

        /// <summary>
        /// Set droppable
        /// </summary>
        /// <param name="status"></param>
        private void SetDroppable(bool status)
        {
            CanDropCard = status;
        }

        public void Init(ICardData sourceCardData, StackCountView stackCountView)
        {
            sourceCard = sourceCardData;
            StackCountView = stackCountView;
            SetDroppable(sourceCard.BaseCard.MaxStackCount > 0);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.LogError($"OnDrop {eventData}");
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            var draggableCardView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            
            if (draggableCardView == null ||
                draggableCardView.CardData.BaseCard.Id != sourceCard.BaseCard.Id ||
                draggableCardView.CardData.InventoryData.OwnerId != sourceCard.InventoryData.OwnerId)
                return;
            
            DropCards.Add(draggableCardView);
            draggableCardView.Hide();
            StackCountView.AddStackCount();
        }
    }
}