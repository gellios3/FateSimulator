using Canvas.Popups.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    public class ActivityPopupView : MonoBehaviour
    {
        [SerializeField] private ActivityPopupCardConditionsView conditionsView;

        [SerializeField] private Button closeBtn;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            closeBtn.onClick.AddListener(() =>
            {
                signalBus.Fire(new CloseActivityPopupSignal());
                gameObject.SetActive(false);
            });
        }

        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            gameObject.SetActive(true);
            conditionsView.Init(obj.SourceActivity.FoundActivity,obj.StartActionCard);
        }
    }
}