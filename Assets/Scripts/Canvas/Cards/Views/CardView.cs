﻿using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using DG.Tweening;
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
    public class CardView : BaseView, ICardView
    {
        #region Parameters

        [SerializeField] private RectTransform mask;

        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;

        [SerializeField] private Image iconImg;
        [SerializeField] private ProceduralImage backgroundImg;
        [SerializeField] private TextMeshProUGUI title;

        // [SerializeField] private List<CardStatusPreset> appearances;

        [SerializeField] private ColorsPresetImage borderImg;

        [SerializeField] private CardStatus currentStatus;

        public GameObject GameObject => gameObject;
        public IBaseCard BaseCard { get; private set; }

        [Inject] private CardAppearanceService CardAppearanceService { get; }

        private Vector2 defaultSizeDelta;

        #endregion

        [Inject]
        public void Construct(IBaseCard cardObj)
        {
            BaseCard = cardObj;
        }

        private void Start()
        {
            defaultSizeDelta = mask.sizeDelta;
        }

        // // @TODO complete logic for card active inactive status 
        // public void SetExhaustionStatus()
        // {
        //     var exhaustionAppear = CardAppearanceService.GetAppearance(CardStatus.Distress);
        //     currentStatus = CardStatus.Distress;
        //     backgroundImg.color = exhaustionAppear.color;
        //     iconImg.color = new Color(
        //         exhaustionAppear.color.r, exhaustionAppear.color.g, exhaustionAppear.color.b, 0.65f
        //     );
        // }

        /// <summary>
        /// Highlight card
        /// </summary>
        public void HighlightCard()
        {
            const float animDuration = 0.5f;
            borderImg.PlayHighlightAnim(animDuration);
            transform.DOScale(1.1f, animDuration).onComplete += () => { transform.DOScale(1f, animDuration); };
        }

        /// <summary>
        /// Set card view
        /// </summary>
        /// <param name="cardObj"></param>
        public void SetCardView(IBaseCard cardObj)
        {
            CardAppearanceService.Init(cardObj.StatusPresets);
            iconImg.sprite = cardObj.CardIcon;
            backgroundImg.color = CardAppearanceService.GetAppearance(CardStatus.Normal).color;
            currentStatus = CardStatus.Normal;
            title.text = cardObj.CardName;
        }

        /// <summary>
        /// On start drag card
        /// </summary>
        public void OnStartDragCard()
        {
            transform.SetAsLastSibling();
            SetDragCartShadow();
        }

        /// <summary>
        /// Set card position
        /// </summary>
        /// <param name="pos"></param>
        public void SetCardPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        /// <summary>
        /// Return default cart shadow
        /// </summary>
        public void ReturnDefaultCartShadow()
        {
            mask.transform.localPosition = new Vector3(defaultMask.x, defaultMask.y, defaultMask.z);
            mask.sizeDelta = defaultSizeDelta;
        }

        /// <summary>
        /// Hide cart shadow
        /// </summary>
        public void HideCartShadow()
        {
            mask.localPosition = Vector3.zero;
            mask.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }

        /// <summary>
        /// Set drag cart shadow
        /// </summary>
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