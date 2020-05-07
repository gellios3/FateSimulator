using System;
using Interfaces;

namespace Canvas.Activities.Interfaces
{
    public interface IActivityView : IBaseView
    {
        ushort ActivityId { get; }
        Action RunTimer { get; }
        Action RefreshActivity { get; }
    }
}