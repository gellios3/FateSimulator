using System;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
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
    public class DraggableCardView : BaseDraggableCardView, IDraggableCardView
    {
        #region Parameters

        public ushort CardId => CardObj.Id;
        public Action<bool> OnOutArea { get; private set; }
        public Action<bool> OnDropOnActivity { get; private set; }
        public Action OnDropCard { get; private set; }
        public Action<Vector3> OnSetPosition { get; private set; }
        public Action<bool> OnReturnBack { get; private set; }

        private ICardView TopCard { get; set; }
        private IBaseCard CardObj { get; set; }

        [SerializeField] private Button openPopupBtn;

        [Inject] private CardSignalsService CardSignalsService { get; }
        [Inject] private CommonCardService CommonCardService { get; }
        [Inject] private DraggableCardService DraggableCardService { get; }

        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj, ICardView topCard)
        {
            CardObj = cardObj;
            TopCard = topCard;
            CommonCardService.AddCardView(this);
            DraggableCardService.Init(CardId);
        }

        private void Start()
        {
            openPopupBtn.onClick.AddListener(() =>
            {
                if (!DraggableCardService.HasStartDrag)
                {
                    CardSignalsService.ShowPopup(CardId);
                }
            });

            OnDropOnActivity += DraggableCardService.OnDropOnActivity;
            OnOutArea += DraggableCardService.SetOutArea;
            OnSetPosition += SetPosition;
            OnDropCard += DropCard;
            OnReturnBack += ReturnBack;
            // Init top card position
            TopCard.SetCardPosition(transform.position);
            TopCard.SetCardView(CardObj);
        }


        public override void Hide()
        {
            base.Hide();
            TopCard.Hide();
        }

        public override void Show()
        {
            base.Show();
            TopCard.Show();
        }

        public void HighlightCard()
        {
            TopCard.HighlightCard();
        }

        /// <summary>
        /// Set card position 
        /// </summary>
        /// <param name="pos"></param>
        private void SetPosition(Vector3 pos)
        {
            transform.position = pos;
            TopCard.SetCardPosition(pos);
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

        /// <summary>
        /// On begin drag
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!DraggableCardService.CanBeginDrag())
                return;

            CardSignalsService.StartDragCard(CardObj.Id);

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
            DraggableCardService.DragCard(eventData.position);
        }

        /// <summary>
        /// On End drag card
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnEndDrag(PointerEventData eventData)
        {
            DraggableCardService.EndDrag();
            EndDrag();
        }

        /// <summary>
        /// Return card back
        /// </summary>
        private void ReturnBack(bool hasSetInInventory = false)
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
        private void DropCard()
        {
            DraggableCardService.DropCard();
            TopCard.SetCardPosition(transform.position);
            TopCard.HideCartShadow();
        }

        /// <summary>
        /// On end drag card
        /// </summary>
        private void EndDrag()
        {
            CardSignalsService.EndDragCard(CardObj.Id);
            if (!DraggableCardService.CanEndDrag())
                return;
            TopCard.ReturnDefaultCartShadow();
        }

        /// <summary>
        /// Zenject Factory for Instantiate
        /// </summary>
        public class Factory : PlaceholderFactory<IBaseCard, ICardView, DraggableCardView>
        {
        }
    }
}