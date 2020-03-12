using Cards.Models;
using ScriptableObjects.Cards;
using UnityEngine;

namespace Cards.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private BaseCardObj sourceCard;

        // public CardData CardData { get; private set; }

        [SerializeField] private RectTransform mask;

        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;
        // [SerializeField] private Vector3 noneMask;

        public void OnDragCard()
        {
            mask.sizeDelta = new Vector2(63, 106);
            mask.transform.localPosition = new Vector3(dragMask.x, dragMask.y, dragMask.z);
        }

        public void OnEndDrag()
        {
            mask.transform.localPosition = new Vector3(defaultMask.x, defaultMask.y, defaultMask.z);
        } 
        
        public void OnDropDrag()
        {
            mask.sizeDelta = new Vector2(50, 90);
            // mask.transform.localPosition -= new Vector3(noneMask.x, noneMask.y, noneMask.z);
        }
    }
}