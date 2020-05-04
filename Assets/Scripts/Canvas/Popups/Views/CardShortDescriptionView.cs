using AbstractViews;
using Canvas.Aspects.Views;
using Canvas.Cards.Services;
using Canvas.Popups.Signals;
using Enums;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Card short description view
    /// </summary>
    public class CardShortDescriptionView : BaseView
    {
        #region Parameters

        [SerializeField] private TextMeshProUGUI titleTxt;
        [SerializeField] private TextMeshProUGUI descriptionTxt;
        [SerializeField] private Image iconBg;
        [SerializeField] private Image iconImg;
        [SerializeField] private AspectsBarView aspectsBarView;

        private SignalBus SignalBus { get; set; }

        [Inject] private CardAppearanceService CardAppearanceService { get; }

        [Inject] private AllItemsDataBase AllItemsDataBase { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            Hide();
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowCardPopupSignal>(ShowCardPopup);
        }

        /// <summary>
        /// Show card popup signal
        /// </summary>
        /// <param name="args"></param>
        private void ShowCardPopup(ShowCardPopupSignal args)
        {
            Show();
            var cardObj = AllItemsDataBase.GetCardById(args.CardId);
            CardAppearanceService.Init(cardObj.StatusPresets);
            titleTxt.text = cardObj.CardName;
            descriptionTxt.text = cardObj.ShortDescription;
            iconImg.sprite = cardObj.CardIcon;
            iconBg.color = CardAppearanceService.GetAppearance(CardStatus.Normal).color;
            aspectsBarView.SetAspectsBar(cardObj);
        }
    }
}