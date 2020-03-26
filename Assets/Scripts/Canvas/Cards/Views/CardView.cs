using Interfaces.Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

namespace Canvas.Cards.Views
{
    /// <summary>
    /// Card View
    /// </summary>
    public class CardView : MonoBehaviour
    {
        [SerializeField] private RectTransform mask;

        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;

        [SerializeField] private Image iconImg;
        [SerializeField] private ProceduralImage backgroundImg;
        [SerializeField] private TextMeshProUGUI title;

       

        private Vector2 defaultSizeDelta;

        private IBaseCard CardObj { get; set; }

        private void Start()
        {
            defaultSizeDelta = mask.sizeDelta;
        }

        public void SetCardView(IBaseCard cardObj)
        {
            CardObj = cardObj;
            iconImg.sprite = cardObj.CardIcon;
            backgroundImg.color = cardObj.BackgroundColor;
            title.text = cardObj.CardName;
        }

        public void OnStartDragCard()
        {
            transform.SetAsLastSibling();
            mask.sizeDelta = defaultSizeDelta;
            mask.transform.localPosition = new Vector3(dragMask.x, dragMask.y, dragMask.z);
        }

        public void OnEndDrag()
        {
            mask.transform.localPosition = new Vector3(defaultMask.x, defaultMask.y, defaultMask.z);
        }

        public void OnDropDrag()
        {
            Debug.LogError("OnDropDrag");
            mask.sizeDelta = new Vector2(50, 90);
            // mask.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
    }
}