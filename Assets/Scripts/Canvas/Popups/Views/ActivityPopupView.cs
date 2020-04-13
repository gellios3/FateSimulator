using Canvas.Activities.Views;
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

        private ActivityView sourceActivityView;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            closeBtn.onClick.AddListener(OnClosePopup);
        }

        private void OnClosePopup()
        {
            sourceActivityView.ReturnToNormalStatus(true);
            gameObject.SetActive(false);
        }

        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            gameObject.SetActive(true);
            sourceActivityView = obj.SourceActivity;
            conditionsView.Init(sourceActivityView.FoundActivity, obj.StartActionCard);
        }
    }
}