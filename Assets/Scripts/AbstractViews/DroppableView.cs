using System;
using Canvas;
using Canvas.Cards.Models;
using Canvas.Cards.Views;
using Enums;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

namespace AbstractViews
{
    public class DroppableView : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// On Card drop
        /// </summary>
        public event Action<IBaseCard> OnCardDrop;

        [SerializeField] private Image bgImg;

        public bool CanDropCard { get; private set; } = true;

        [SerializeField] private ColorsPresetImage borderImg;

        public void SetDroppable(bool status)
        {
            CanDropCard = status;
            bgImg.raycastTarget = status;
        }
        

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null || !CanDropCard)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (draggableView == null)
                return;
            draggableView.transform.position = transform.position;
            OnCardDrop?.Invoke(draggableView.CardObj);
            draggableView.OnDropCard();
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
            borderImg.SetStatus(Status.Highlighted);
            // Debug.LogError($"OnPointerEnter {eventData.pointerDrag}");   
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
            borderImg.SetStatus(Status.Normal);
            var cardView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (cardView != null)
            {
                // cardView.CanDraggable = true;
                // Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
            }
        }
    }
}