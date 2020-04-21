using Canvas.Popups.Signals;
using Interfaces.Aspects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Aspect popup
    /// </summary>
    public class AspectDescriptionPopupView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Button closeBtn;

        private IBaseAspect BaseAspect { get; set; }
        private SignalBus SignalBus { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            gameObject.SetActive(false);
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowAspectPopupSignal>(ShowAspectPopup);
            
            closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
        }

        private void ShowAspectPopup(ShowAspectPopupSignal signal)
        {
            BaseAspect = signal.BaseAspectObj;

            title.text = BaseAspect.AspectName;
            description.text = BaseAspect.AspectDescription;
            icon.sprite = BaseAspect.AspectImg;
            gameObject.SetActive(true);
        }
    }
}