using System;
using Enums;
using Interfaces;
using Interfaces.Cards;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    /// <summary>
    /// Draggable card view
    /// </summary>
    public interface IDraggableCardView : IBaseView
    {
        ICardData CardData { get; }
        ICardView TopCard { get; }
        Action<bool> OnDropOnActivity { get; }
        Action<bool> OnOutArea { get; }
        Action<Vector3> OnSetPosition { get; }
        Action OnDropCard { get; }
        Action OnReturnBack { get; }
        Action OnHighlight { get; }
        Action<CardStatus> OnChangeStatus { get; }
    }
}