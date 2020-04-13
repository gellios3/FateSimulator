using AbstractViews;
using Canvas.Popups.Signals;
using Enums;
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
        }

        public void ReturnDropCard( )
        {
            if (DropCardView == null)
                return;
            borderImg.SetStatus(Status.Normal);
            DropCardView.Show();
            DropCardView.ReturnBack(false);
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