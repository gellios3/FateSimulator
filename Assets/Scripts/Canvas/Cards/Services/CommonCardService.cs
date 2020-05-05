using System.Collections.Generic;
using Canvas.Cards.Interfaces;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Common card service
    /// </summary>
    public class CommonCardService
    {
        /// <summary>
        /// Draggable card View
        /// </summary>
        public List<IDraggableCardView> DraggableCardViews { get; } = new List<IDraggableCardView>();
        
        /// <summary>
        /// Get draggable card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDraggableCardView GetDraggableCardById(ushort id)
        {
            return id > 0 ? DraggableCardViews.Find(view => view.CardId == id) : null;
        }

        /// <summary>
        /// Add draggable view
        /// </summary>
        /// <param name="draggableCardView"></param>
        public void AddCardView(IDraggableCardView draggableCardView)
        {
            DraggableCardViews.Add(draggableCardView);
        }
    }
}