﻿using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Enums;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Cards.Views
{
    /// <summary>
    /// Not visible but draggable card on the table 
    /// </summary>
    public class DraggableCardView : BaseDraggableCardView
    {
        #region Parameters

        public override ushort CardId => CardObj.Id;
        private IBaseCard CardObj { get; set; }
        
        [SerializeField] private Button openPopupBtn;
        [Inject] private CardSignalsService CardSignalsService { get; }
        [Inject] private CardViewsService CardViewsService { get; }
        [Inject] private DraggableCardService DraggableCardService { get; }
        [Inject] private CardAppearanceService CardAppearanceService { get; }

        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj, ICardView topCard)
        {
            CardObj = cardObj;
            TopCard = topCard;
            CardViewsService.AddCardView(this);
            CardAppearanceService.Init(cardObj.StatusPresets);

            InitActions();
            openPopupBtn.onClick.AddListener(() =>
            {
                if (!DraggableCardService.HasStartDrag)
                {
                    CardSignalsService.ShowPopup(CardId);
                }
            });

            TopCard.TimerFinish += OnCardTimerFinish;
        }

        private void Start()
        {
            // Init top card position
            TopCard.SetCardPosition(transform.position);
            TopCard.SetCardView(CardAppearanceService.GetAppearance(CardStatus.Normal));
        }

        /// <summary>
        /// Hide
        /// </summary>
        public override void Hide()
        {
            base.Hide();
            TopCard.Hide();
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
            TopCard.Show();
        }

        /// <summary>
        /// Set start position
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="parent"></param>
        public void SetStartPos(Vector3 pos, Transform parent)
        {
            var tempTransform = transform;
            tempTransform.parent = parent;
            tempTransform.localPosition = pos;
            tempTransform.localRotation = Quaternion.identity;
        }

        #region Drag Events

        /// <summary>
        /// On begin drag
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!DraggableCardService.CanBeginDrag())
                return;

            CardSignalsService.StartDragCard(this);

            TopCard.Show();
            DraggableCardService.SetTempPos(transform.position);
            TopCard.OnStartDragCard();
        }

        /// <summary>
        /// On drag card
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDrag(PointerEventData eventData)
        {
            if (DraggableCardService.CanDragCard())
                SetPosition(DraggableCardService.GetWorldPositionOnPlane(eventData.position, -1));
        }

        /// <summary>
        /// On End drag card
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnEndDrag(PointerEventData eventData)
        {
            if (DraggableCardService.HasOutDrag())
                ReturnBack(false);
            CardSignalsService.EndDragCard(CardObj.Id);
            if (!DraggableCardService.CanEndDrag())
                return;
            TopCard.ReturnDefaultCartShadow();
        }

        #endregion

        #region Action Methods

        /// <summary>
        /// Highlight card
        /// </summary>
        protected override void HighlightCard()
        {
            TopCard.HighlightCard();
        }

        /// <summary>
        /// Set card position 
        /// </summary>
        /// <param name="pos"></param>
        protected override void SetPosition(Vector3 pos)
        {
            transform.position = pos;
            TopCard.SetCardPosition(pos);
        }

        /// <summary>
        /// Return card back
        /// </summary>
        protected override void ReturnBack(bool hasSetInInventory)
        {
            DraggableCardService.ReturnBack(hasSetInInventory);
            SetPosition(DraggableCardService.TempPosition);
            if (hasSetInInventory)
                TopCard.HideCartShadow();
            else
                TopCard.ReturnDefaultCartShadow();
        }

        /// <summary>
        /// On drop card
        /// </summary>
        protected override void DropCard()
        {
            DraggableCardService.DropCard();
            TopCard.SetCardPosition(transform.position);
            TopCard.HideCartShadow();
        }

        /// <summary>
        /// Change card status
        /// </summary>
        /// <param name="status"></param>
        protected override void ChangeCardStatus(CardStatus status)
        {
            var appearance = CardAppearanceService.GetAppearance(status);
            if (appearance == null)
                return;
            TopCard.SetStatusPreset(appearance);
            TopCard.InitCardTimer(appearance);
        }

        /// <summary>
        /// Set drop on activity
        /// </summary>
        /// <param name="value"></param>
        protected override void SetDropOnActivity(bool value)
        {
            DraggableCardService.OnDropOnActivity(value);
        }

        /// <summary>
        /// Set out area
        /// </summary>
        /// <param name="value"></param>
        protected override void SetOutArea(bool value)
        {
            DraggableCardService.SetOutArea(value);
        }

        #endregion
        
        /// <summary>
        /// On card timer finish
        /// </summary>
        /// <param name="finishStatus"></param>
        protected override void OnCardTimerFinish(CardStatus finishStatus)
        {
            // @todo finish timer status logic 
            switch (finishStatus)
            {
                case CardStatus.Broken:
                    Debug.Log("CardTimerFinish Broken !!!");
                    break;
                case CardStatus.Death:
                    Hide();
                    Debug.Log("CardTimerFinish Death !!!");
                    break;
                default:
                    TopCard.SetCardView(CardAppearanceService.GetAppearance(CardStatus.Normal));
                    TopCard.HideTimer();
                    break;
            }
        }

        /// <summary>
        /// Zenject Factory for Instantiate
        /// </summary>
        public class Factory : PlaceholderFactory<IBaseCard, ICardView, DraggableCardView>
        {
        }
    }
}