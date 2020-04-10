using AbstractViews;
using Canvas.Popups.Signals;
using UnityEngine.EventSystems;
using Zenject;

namespace Canvas.Activities.Views
{
    public class ActivityDroppableView : DroppableView
    {
        private SignalBus SignalBus { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            signalBus.Subscribe<CloseActivityPopupSignal>(OnReturnDropCard);
        }

        private void OnReturnDropCard()
        {
            if (DropCardView == null)
                return;
            DropCardView.Show();
            DropCardView.ReturnBack();
            DropCardView = null;
        }


        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            if (DropCardView == null)
                return;
            DropCardView.HasActivate = true;
            // DropCardView.Hide();
        }
    }
}