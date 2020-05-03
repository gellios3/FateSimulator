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
        public Action<bool> OutArea { get; private set; }
        public Action<bool> OnDropOnActivity { get; private set; }

        private ICardView TopCard { get; set; }
        private IBaseCard CardObj { get; set; }

        [SerializeField] private Button openPopupBtn;

        [Inject] private CommonCardService CommonCardService { get; }
        [Inject] private DraggableCardService DraggableCardService { get; }

        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj, ICardView topCard)
        {
            CardObj = cardObj;
            TopCard = topCard;

            CommonCardService.AddCardView(TopCard);
            CommonCardService.AddDraggableView(this);
            DraggableCardService.Init(this);
        }

        private void Start()
        {
            openPopupBtn.onClick.AddListener(() =>
            {
                if (!DraggableCardService.HasStartDrag)
                {
                    CommonCardService.ShowPopup(CardObj);
                }
            });

            OnDropOnActivity += DraggableCardService.OnDropOnActivity;
            OutArea += DraggableCardService.SetOutArea;
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

        /// <summary>
        /// Set card position 
        /// </summary>
        /// <param name="pos"></param>
        public void SetPosition(Vector3 pos)
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

            CommonCardService.StartDragCard(CardObj);

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
        public void ReturnBack(bool hasSetInInventory = false)
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
        public void OnDropCard()
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
            CommonCardService.EndDragCard(CardObj);
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