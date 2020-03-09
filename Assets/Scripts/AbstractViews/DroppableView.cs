using System;
using Cards.Models;
using Cards.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AbstractViews
{
    public sealed class DroppableView : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// On Card drop
        /// </summary>
        public event Action<CardData> OnCardDrop;

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var cardView = eventData.pointerDrag.GetComponent<CardView>();
            if (cardView != null)
            {
                Debug.LogError($"OnDrop {cardView.CardData}");
                OnCardDrop?.Invoke(cardView.CardData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer enter
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            // Debug.LogError($"OnPointerEnter {eventData.pointerDrag}");   
        }

        /// <inheritdoc />
        /// <summary>
        /// On pointer exit
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            // Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
        }
    }
}