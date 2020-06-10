using System;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Canvas.Common;
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
        #region Punlic Parameters
        private ICardData CardData { get; set; }
        public Action<CardStatus> TimerFinish { get; set; }
        public CardStatusPreset CurrentStatus { get; private set; }

        #endregion

        #region Parameters

        [SerializeField] private RectTransform mask;
        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;
        [SerializeField] private Image iconImg;
        [SerializeField] private ProceduralImage backgroundImg;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private ColorsPresetImageView borderImg;
        [SerializeField] private TimerView cardTimer;

        private Vector2 defaultSizeDelta;

        #endregion

        [Inject]
        public void Construct(ICardData cardObj)
        {
            CardData = cardObj;
            cardTimer.TimeFinish += OnTimerFinish;
            defaultSizeDelta = mask.sizeDelta;
            HideCartShadow();
        }

        #region Card timer

        /// <summary>
        /// Start Card timer
        /// </summary>
        /// <param name="preset"></param>
        public void InitCardTimer(CardStatusPreset preset)
        {
            cardTimer.Init(preset.duration);
            StartCardTimer();
        }

        public void HideTimer()
        {
            cardTimer.Hide();
        }

        /// <summary>
        /// Start card timer
        /// </summary>
        private void StartCardTimer()
        {
            cardTimer.Show();
            SetCardView(CurrentStatus);
        }

        /// <summary>
        /// On end Timer
        /// </summary>
        private void OnTimerFinish()
        {
            TimerFinish?.Invoke(CurrentStatus.cardStatus);
        }

        #endregion

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
        /// <param name="preset"></param>
        public void SetCardView(CardStatusPreset preset)
        {
            SetStatusPreset(preset);
            iconImg.sprite = CardData.BaseCard.CardIcon;
            ColorHelper.SetImgColor(backgroundImg, preset.color);
            title.text = CardData.BaseCard.CardName;
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

        public void SetStatusPreset(CardStatusPreset preset)
        {
            CurrentStatus = preset;
        }

        public class Factory : PlaceholderFactory<ICardData, CardView>
        {
        }
    }
}