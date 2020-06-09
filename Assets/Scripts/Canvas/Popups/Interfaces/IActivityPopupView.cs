using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Interfaces.Activity;
using Interfaces.Cards;

namespace Canvas.Popups.Interfaces
{
    public interface IActivityPopupView
    {
        void ShowResultPopup(IBaseActivity baseActivity, IEnumerable<IDraggableCardView> runCardViews,
            IEnumerable<ICardData> resultList);

        void ShowActivityPopup(IBaseActivity baseActivity, ushort cardId);
    }
}