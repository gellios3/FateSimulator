using AbstractViews;
using Enums;
using UnityEngine.EventSystems;

namespace Canvas.Activities.Views
{
    public class ActivityDroppableView : DroppableView
    {

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
        }
    }
}