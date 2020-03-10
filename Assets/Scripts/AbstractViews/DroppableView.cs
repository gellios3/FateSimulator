using System;
using Cards.Models;
using Cards.Views;
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

        // public event Action<GameObject> OnCardEnter;
        // public event Action<GameObject> OnCardExit;

        /// <inheritdoc />
        /// <summary>
        /// On drop 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var cardView = eventData.pointerDrag.GetComponent<DraggableView>();
            if (cardView != null)
            {
                Debug.LogError($"OnDrop ");
                cardView.transform.position = transform.position;
                OnCardDrop?.Invoke(null);
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