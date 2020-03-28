using AbstractViews;
using Canvas.Cards.Services;
using Canvas.Popups.Signals;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Cards.Views
{
    public class DraggableView : BaseItem, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool CanDraggable { private get; set; } = true;
        private bool HasDrop { get; set; }
        public bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        private bool HasStartDrag { get; set; }

        public Vector3 startTempPosition;

        [SerializeField] private Button openPopupBtn;

        private CardView TopCard { get; set; }
        
        private IBaseCard CardObj { get; set; }

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
                    Debug.LogError("Show popup");
                // DraggableCardService.ShowPopup(CardObj);
            });
        }

        public void SetCardView(CardView topCard, IBaseCard cardObj)
        {
            CardObj = cardObj;
            TopCard = topCard;
            TopCard.transform.position = transform.position;
            TopCard.SetCardView(cardObj);
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
            transform.position = pos;
            TopCard.transform.position = pos;
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
                ReturnBack();
                return;
            }

            HasSetInInventory = false;

            if (!CanDraggable)
                return;

            CallEndDrag();
        }

        private void ReturnBack()
        {
            HasOutArea = false;
            transform.position = startTempPosition;
            TopCard.transform.position = startTempPosition;
            var cardView = TopCard.GetComponent<CardView>();
            if (cardView != null)
            {
                if (HasSetInInventory)
                    cardView.OnDropDrag();
                else
                    cardView.OnEndDrag();
            }
        }

        private void CallEndDrag()
        {
            var cardView = TopCard.GetComponent<CardView>();
            if (!HasOutArea)
                CanDraggable = true;
            if (cardView != null)
            {
                cardView.OnEndDrag();
            }
        }

        /// <summary>
        /// On drop card
        /// </summary>
        public void OnDropCard()
        {
            var cardView = TopCard.GetComponent<CardView>();
            if (cardView != null)
            {
                HasDrop = true;
                HasSetInInventory = true;
                TopCard.transform.position = transform.position;
                cardView.OnDropDrag();
            }
        }

        public class Factory : PlaceholderFactory<IBaseCard, DraggableView>
        {
        }
    }
}