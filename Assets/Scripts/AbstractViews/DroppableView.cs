using System;
using Canvas.Cards.Models;
using Canvas.Cards.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.ProceduralImage;

namespace AbstractViews
{
    public sealed class DroppableView : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// On Card drop
        /// </summary>
        public event Action<CardData> OnCardDrop;

        [SerializeField] private ProceduralImage borderImg;

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (draggableView != null)
            {
                Debug.LogError("On Drop event !!! ");
                draggableView.transform.position = transform.position;
                OnCardDrop?.Invoke(null);
                draggableView.OnDropCard();
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
            borderImg.color = Color.black;
          

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
            borderImg.color = Color.white;
            var cardView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (cardView != null)
            {
                // cardView.CanDraggable = true;
                // Debug.LogError($"OnPointerExit {eventData.pointerDrag}");
            }
        }
    }
}