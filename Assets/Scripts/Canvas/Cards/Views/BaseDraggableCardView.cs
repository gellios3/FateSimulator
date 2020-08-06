using System;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Enums;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Canvas.Cards.Views
{
    /// <summary>
    /// Base draggable cardView
    /// </summary>
    public abstract class BaseDraggableCardView : BaseView, IDraggableCardView, IBeginDragHandler, IDragHandler,
        IEndDragHandler
    {
        #region Actions
        public ICardData CardData { get; protected set;}
        public ICardView TopCard { get; protected set; }
        public Action<bool> OnOutArea { get; private set; }
        public Action<bool> OnDropOnActivity { get; private set; }
        public Action OnDropCard { get; private set; }
        public Action<Vector3> OnSetPosition { get; private set; }
        public Action OnReturnBack { get; private set; }
        public Action OnHighlight { get; private set; }
        public Action<CardStatus> OnChangeStatus { get; private set; }

        #endregion

        protected void InitActions()
        {
            OnDropOnActivity += SetDropOnActivity;
            OnOutArea += SetOutArea;
            OnSetPosition += SetPosition;
            OnDropCard += DropCard;
            OnReturnBack += ReturnBack;
            OnHighlight += HighlightCard;
            OnChangeStatus += ChangeCardStatus;
        }
        
        #region Action Methods
        
        protected abstract void ChangeCardStatus(CardStatus obj);
        protected abstract void SetDropOnActivity(bool value);
        protected abstract void SetOutArea(bool value);
        protected abstract void SetPosition(Vector3 obj);
        protected abstract void DropCard();
        protected abstract void ReturnBack();
        protected abstract void HighlightCard();

        #endregion

        public abstract void OnBeginDrag(PointerEventData eventData);
        public abstract void OnDrag(PointerEventData eventData);
        public abstract void OnEndDrag(PointerEventData eventData);
    }
}