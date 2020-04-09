using Canvas.Popups.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views
{
    public class ActivityPopupView : MonoBehaviour
    {
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
        }

        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            // obj.BaseActivity
            gameObject.SetActive(true);
        }
    }
}