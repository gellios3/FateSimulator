using Canvas.Popups.Signals;
using Canvas.Popups.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups
{
    /// <summary>
    /// Card short description view
    /// </summary>
    public class CardShortDescriptionView : MonoBehaviour
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
            gameObject.SetActive(false);
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowCardPopupSignal>(ShowCardPopup);
        }

        /// <summary>
        /// Show card popup signal
        /// </summary>
        /// <param name="args"></param>
        private void ShowCardPopup(ShowCardPopupSignal args)
        {
            gameObject.SetActive(true);
            var cardObj = args.BaseCard;
            titleTxt.text = cardObj.CardName;
            descriptionTxt.text = cardObj.ShortDescription;
            iconImg.sprite = cardObj.CardIcon;
            iconBg.color = cardObj.BackgroundColor;
            aspectsBarView.SetAspectsBar(cardObj.AspectsList);
        }
    }
}