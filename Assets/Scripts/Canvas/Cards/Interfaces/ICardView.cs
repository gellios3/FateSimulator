using Interfaces.Cards;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    public interface ICardView
    {
        GameObject GameObject { get; }
        
        IBaseCard BaseCard { get; }
        
        void SetCardPosition(Vector3 pos);
        void SetCardView(IBaseCard cardObj);
        void OnStartDragCard();
        void HideCartShadow();
        void ReturnDefaultCartShadow();
        void HighlightCard();

    }
}