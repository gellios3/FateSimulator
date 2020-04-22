using Interfaces;
using Interfaces.Cards;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    public interface ICardView: IBaseView
    {
        IBaseCard BaseCard { get; }
        
        void SetCardPosition(Vector3 pos);
        void SetCardView(IBaseCard cardObj);
        void OnStartDragCard();
        void HideCartShadow();
        void ReturnDefaultCartShadow();
        void HighlightCard();

    }
}