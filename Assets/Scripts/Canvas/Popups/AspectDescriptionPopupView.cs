using Canvas.Popups.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups
{
    public class AspectDescriptionPopupView : MonoBehaviour
    {
        private SignalBus SignalBus { get; set; }
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            gameObject.SetActive(false);
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowAspectPopupSignal>(ShowAspectPopup);
        }

        private void ShowAspectPopup()
        {
            gameObject.SetActive(true);
        }
    }
}