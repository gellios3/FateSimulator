using AbstractViews;
using Canvas.Aspects.Views;
using Canvas.Popups.Signals;
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
        [SerializeField] private TextMeshProUGUI titleTxt;
        [SerializeField] private TextMeshProUGUI descriptionTxt;
        [SerializeField] private Image iconBg;
        [SerializeField] private Image iconImg;
        [SerializeField] private AspectsBarView aspectsBarView;

        private SignalBus SignalBus { get; set; }

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
            var cardObj = args.BaseCard;
            titleTxt.text = cardObj.CardName;
            descriptionTxt.text = cardObj.ShortDescription;
            iconImg.sprite = cardObj.CardIcon;
            iconBg.color = cardObj.BackgroundColor;
            aspectsBarView.SetAspectsBar(cardObj);
        }
    }
}