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

        private bool CanDraggable { get; set; } = true;
        private bool HasDrop { get; set; }
        private bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        private bool HasStartDrag { get; set; }

        private Vector3 startTempPosition;

        [SerializeField] private Button openPopupBtn;

        private ICardView TopCard { get; set; }

        private IBaseCard CardObj { get; set; }

        [Inject] private DraggableCardService DraggableCardService { get; }

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

        /// <summary>
        /// Init draggable
        /// </summary>
        /// <param name="topCard"></param>
        /// <param name="cardObj"></param>
        public void Init(ICardView topCard, IBaseCard cardObj)
        {
            CardObj = cardObj;
            TopCard = topCard;
            TopCard.SetCardPosition(transform.position);
            TopCard.SetCardView(cardObj);
            DraggableCardService.AddCardView(TopCard);
        }

        /// <summary>
        /// Set out area
        /// </summary>
        /// <param name="value"></param>
        public void SetOutArea(bool value)
        {
            HasOutArea = value;
        }

        public void SetDraggable(bool value)
        {
            CanDraggable = value;
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

        public void SetStartPos(Vector3 pos,Transform parent)
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
            if (!CanDraggable)
                return;

            HasDrop = false;
            HasStartDrag = true;

            DraggableCardService.StartDragCard(CardObj);

            TopCard.Show();
            startTempPosition = transform.position;
            TopCard.OnStartDragCard();
        }
        
        /// <summary>
        /// On drag card
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDrag(PointerEventData eventData)
        {
            if (!CanDraggable || Camera.main == null)
                return;
            var pos = GetWorldPositionOnPlane(eventData.position, -1);
            SetPosition(pos);
        }
        
        /// <summary>
        /// On End drag card
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnEndDrag(PointerEventData eventData)
        {
            HasStartDrag = false;

            // if (HasDrop)
            //     return;

            if (HasOutArea)
            {
                ReturnBack(HasSetInInventory);
                return;
            }

            HasSetInInventory = false;

            // if (!CanDraggable)
            //     return;

            EndDrag();
        }

        /// <summary>
        /// Return card back
        /// </summary>
        public void ReturnBack(bool hasSetInInventory = false)
        {
            HasOutArea = false;
            SetPosition(startTempPosition);
            HasSetInInventory = hasSetInInventory;
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
            HasDrop = true;
            HasSetInInventory = true;
            TopCard.SetCardPosition(transform.position);
            TopCard.HideCartShadow();
        }

        /// <summary>
        /// On end drag card
        /// </summary>
        private void EndDrag()
        {
            DraggableCardService.EndDragCard(CardObj);
            if (HasDrop)
                return;
            if (!HasOutArea)
                CanDraggable = true;

            TopCard.ReturnDefaultCartShadow();
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

        /// <summary>
        /// Zenject Factory for Instantiate
        /// </summary>
        public class Factory : PlaceholderFactory<IBaseCard, DraggableCardView>
        {
        }
    }
}