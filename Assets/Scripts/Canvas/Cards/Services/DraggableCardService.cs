using Canvas.Cards.Interfaces;
using Interfaces.Cards;
using UnityEngine;

namespace Canvas.Cards.Services
{
    public class DraggableCardService
    {
        #region Parameters

        private bool CanDraggable { get; set; } = true;
        private bool HasDrop { get; set; }
        private bool HasOutArea { get; set; }
        private bool HasSetInInventory { get; set; }
        private bool HasStartDrag { get; set; }
        private Vector3 startTempPosition;
        private ICardView TopCard { get; set; }

        private IBaseCard CardObj { get; set; }

        #endregion
        
        public void Init(ICardView topCard, IBaseCard cardObj)
        {
            CardObj = cardObj;
            TopCard = topCard;
        }
        
        public void SetDraggable(bool value)
        {
            CanDraggable = value;
        }
    }
}