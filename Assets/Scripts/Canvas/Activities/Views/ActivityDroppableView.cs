using AbstractViews;
using Enums;

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
            DropCardView.ReturnBack();
            DropCardView = null;
        }
    }
}