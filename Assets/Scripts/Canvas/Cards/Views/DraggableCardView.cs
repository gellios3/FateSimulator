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
    public class DraggableCardView : BaseDraggableCardView
    {
        #region Parameters

        public override ushort CardId => CardObj.Id;
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
        }

        private void Start()
        {
            InitActions();
            openPopupBtn.onClick.AddListener(() =>
            {
                if (!DraggableCardService.HasStartDrag)
                {
                    CardSignalsService.ShowPopup(CardId);
                }
            });

            // Init top card position
            TopCard.SetCardPosition(transform.position);
            TopCard.SetCardView(CardObj);
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
        /// Zenject Factory for Instantiate
        /// </summary>
        public class Factory : PlaceholderFactory<IBaseCard, ICardView, DraggableCardView>
        {
        }
    }
}