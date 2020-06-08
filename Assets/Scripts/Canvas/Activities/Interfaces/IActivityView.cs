using System;
using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Interfaces;

namespace Canvas.Activities.Interfaces
{
    public interface IActivityView : IBaseView
    {
        ushort ActivityId { get; }
        ushort StartActivityCardId { get; }
        Action RunTimer { get; }
        void RunActivity(IEnumerable<IDraggableCardView> dropCardViews);
        void RefreshActivity();
        void OnFinishActivity();
    }
}