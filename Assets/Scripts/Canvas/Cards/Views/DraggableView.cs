using AbstractViews;
using Canvas.Cards.Services;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Cards.Views
{
    public class DraggableView : BaseItem, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Parameters
        
        public bool CanDraggable { private get; set; } = true;
        private bool HasDrop { get; set; }
        public bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        private bool HasStartDrag { get; set; }
        public bool HasActivate { get; set; }

        public Vector3 startTempPosition;

        [SerializeField] private Button openPopupBtn;

        private CardView TopCard { get; set; }

        private IBaseCard CardObj { get; set; }

        [Inject] public DraggableCardService DraggableCardService { get; }
        
        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj)
        {
            CardObj = cardObj;
        }

        private void Start()
        {
            openPopupBtn.onClick.AddListener(() =>
            {
                if (!HasStartDrag)
                {
                    DraggableCardService.ShowPopup(CardObj);
                }
            });
        }
        
        public void Init(CardView topCard, IBaseCard cardObj)
        {
            CardObj = cardObj;
            TopCard = topCard;
            TopCard.SetCardPosition(transform.position);
            TopCard.SetCardView(cardObj);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            TopCard.gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            TopCard.gameObject.SetActive(true);
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

        /// <inheritdoc />
        /// <summary>
        /// On begin drag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!CanDraggable)
                return;

            HasDrop = false;
            HasStartDrag = true;
            HasActivate = false;

            DraggableCardService.StartDragCard(CardObj);

            TopCard.gameObject.SetActive(true);
            startTempPosition = transform.position;
            var cardView = TopCard.GetComponent<CardView>();
            if (cardView != null)
                cardView.OnStartDragCard();
        }

        /// <inheritdoc />
        /// <summary>
        /// On drag card
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if (!CanDraggable || Camera.main == null)
                return;
            var pos = GetWorldPositionOnPlane(eventData.position, -1);
            SetPosition(pos);
        }

        /// <inheritdoc />
        /// <summary>
        /// On End drag card
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            HasStartDrag = false;

            if (HasDrop)
                return;

            if (HasOutArea)
            {
                ReturnBack(HasSetInInventory);
                return;
            }

            HasSetInInventory = false;

            if (!CanDraggable)
                return;

            EndDrag();
        }

        /// <summary>
        /// Return card back
        /// </summary>
        public void ReturnBack(bool hasSetInInventory = false)
        {
            HasOutArea = false;
            SetPosition(startTempPosition);
            var cardView = TopCard.GetComponent<CardView>();
            if (cardView == null) 
                return;
            HasSetInInventory = hasSetInInventory;
            if (hasSetInInventory)
                cardView.HideCartShadow();
            else
                cardView.ReturnDefaultCartShadow();
        }

        /// <summary>
        /// On drop card
        /// </summary>
        public void OnDropCard()
        {
            var cardView = TopCard.GetComponent<CardView>();
            if (cardView == null) 
                return;
            HasDrop = true;
            HasSetInInventory = true;
            TopCard.SetCardPosition(transform.position);
            cardView.HideCartShadow();
        }
        
        private void EndDrag()
        {
            DraggableCardService.EndDragCard(CardObj);
            var cardView = TopCard.GetComponent<CardView>();
            if (!HasOutArea)
                CanDraggable = true;
            if (cardView != null)
            {
                cardView.ReturnDefaultCartShadow();
            }
        }
        
        /// <summary>
        /// Get World position on plane
        /// </summary>
        /// <param name="screenPosition"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private static Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
        {
            if (Camera.main == null)
                return Vector3.zero;
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            var xy = new Plane(Vector3.down, new Vector3(0, 0, z));
            xy.Raycast(ray, out var distance);
            return ray.GetPoint(distance);
        }

        public class Factory : PlaceholderFactory<IBaseCard, DraggableView>
        {
        }
    }
}