using System.Collections.Generic;
using Canvas.Cards.Services;
using Enums;
using Interfaces.Cards;
using Serializable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;
using Zenject;

namespace Canvas.Cards.Views
{
    /// <summary>
    /// Card View
    /// </summary>
    public class CardView : MonoBehaviour
    {
        #region Parameters

        [SerializeField] private RectTransform mask;

        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;

        [SerializeField] private Image iconImg;
        [SerializeField] private ProceduralImage backgroundImg;
        [SerializeField] private TextMeshProUGUI title;

        [SerializeField] private List<StatusAppearance> appearances;

        [SerializeField] private CardStatus currentStatus;

        [Inject] private CardAppearanceService CardAppearanceService { get; }

        private Vector2 defaultSizeDelta;

        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj)
        {
        }

        private void Start()
        {
            defaultSizeDelta = mask.sizeDelta;
            CardAppearanceService.Init(appearances);
        }

        // @TODO complete logic for card active inactive status 
        public void SetExhaustionStatus()
        {
            var exhaustionAppear = CardAppearanceService.GetAppearance(CardStatus.Exhaustion);
            currentStatus = CardStatus.Exhaustion;
            backgroundImg.color = exhaustionAppear.color;
            iconImg.color = new Color(
                exhaustionAppear.color.r, exhaustionAppear.color.g, exhaustionAppear.color.b, 0.65f
            );
        }

        public void SetCardView(IBaseCard cardObj)
        {
            iconImg.sprite = cardObj.CardIcon;
            backgroundImg.color = cardObj.BackgroundColor;
            currentStatus = CardStatus.Normal;
            CardAppearanceService.SetAppearance(CardStatus.Normal, cardObj.BackgroundColor);
            title.text = cardObj.CardName;
        }

        public void OnStartDragCard()
        {
            transform.SetAsLastSibling();
            SetDragCartShadow();
        }

        public void SetCardPosition(Vector3 pos)
        {
            transform.position = pos;
        }
        
        public void ReturnDefaultCartShadow()
        {
            mask.transform.localPosition = new Vector3(defaultMask.x, defaultMask.y, defaultMask.z);
            mask.sizeDelta = defaultSizeDelta;
        }

        public void HideCartShadow()
        {
            mask.localPosition = Vector3.zero;
            mask.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
        
        private void SetDragCartShadow()
        {
            mask.sizeDelta = defaultSizeDelta;
            mask.transform.localPosition = new Vector3(dragMask.x, dragMask.y, dragMask.z);
        }

        public class Factory : PlaceholderFactory<IBaseCard, CardView>
        {
        }
    }
}