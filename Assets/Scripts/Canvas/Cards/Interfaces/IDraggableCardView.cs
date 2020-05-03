using System;
using Interfaces;
using UnityEngine;

namespace Canvas.Cards.Interfaces
{
    /// <summary>
    /// Draggable card view
    /// </summary>
    public interface IDraggableCardView : IBaseView
    {
        ushort CardId { get; }
        Action<bool> OnDropOnActivity { get; }
        Action<bool> OutArea { get; }
        void SetPosition(Vector3 pos);
        void OnDropCard();
        void ReturnBack(bool hasSetInInventory = false);
        void SetStartPos(Vector3 pos, Transform parent);
    }
}