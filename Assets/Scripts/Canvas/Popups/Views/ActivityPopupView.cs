using Canvas.Popups.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views
{
    public class ActivityPopupView : MonoBehaviour
    {
        [SerializeField] private ActivityPopupCardConditionsView conditionsView;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
        }

        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            // obj.BaseActivity
            gameObject.SetActive(true);
            conditionsView.Init(obj.BaseActivity);
        }
    }
}