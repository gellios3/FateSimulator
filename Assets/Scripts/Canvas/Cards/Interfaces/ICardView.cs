using System;
using Canvas.Cards.Views;
using Enums;
using Interfaces;
using Interfaces.Cards;
using Serializable;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    public interface ICardView: IBaseView
    {
        Action<CardStatus> TimerFinish { get; set; }
        CardStatusPreset CurrentStatus { get; }
        StackCountView CountView { get; }
        void SetCardPosition(Vector3 pos);
        void SetCardView(CardStatusPreset preset);
        void OnStartDragCard();
        void HideCartShadow();
        void ReturnDefaultCartShadow();
        void HighlightCard();
        void InitCardTimer(CardStatusPreset duration);
        void HideTimer();
        void SetStatusPreset(CardStatusPreset preset);

    }
}