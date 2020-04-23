using AbstractViews;
using Enums;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity droppable view
    /// </summary>
    public class ActivityDroppableView : DroppableView
    {
        /// <summary>
        /// Return drop card
        /// </summary>
        public void ReturnDropCard( )
        {
            if (DropCardCardView == null)
                return;
            borderImg.SetStatus(Status.Normal);
            DropCardCardView.Show();
            DropCardCardView.ReturnBack();
            DropCardCardView = null;
        }
    }
}