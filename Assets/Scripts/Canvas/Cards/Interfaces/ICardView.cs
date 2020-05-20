using Interfaces;
using Interfaces.Cards;
using Serializable;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    public interface ICardView: IBaseView
    {
        IBaseCard BaseCard { get; }
        void SetCardPosition(Vector3 pos);
        void SetCardView(CardStatusPreset preset);
        void OnStartDragCard();
        void HideCartShadow();
        void ReturnDefaultCartShadow();
        void HighlightCard();
        void InitCardTimer(CardStatusPreset duration);

    }
}