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
        Action<bool> OnSetDraggable { get; }
        void SetPosition(Vector3 pos);
        void OnDropCard();
        void ReturnBack(bool hasSetInInventory = false);
        void SetOutArea(bool value);
        void SetStartPos(Vector3 pos, Transform parent);
        void SetDraggable(bool value);
    }
}