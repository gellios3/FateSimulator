using System.Collections.Generic;
using Canvas.Cards.Interfaces;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Common card views service
    /// </summary>
    public class CardViewsService
    {
        /// <summary>
        /// Draggable card Views
        /// </summary>
        private List<IDraggableCardView> DraggableCardViews { get; } = new List<IDraggableCardView>();
        
        /// <summary>
        /// Get draggable card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDraggableCardView GetDraggableCardById(ushort id)
        {
            return id > 0 ? DraggableCardViews.Find(view => view.CardData.BaseCard.Id == id) : null;
        }

        /// <summary>
        /// Get all draggable cards by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<IDraggableCardView> GetAllCardsById(ushort id)
        {
            return id > 0 ? DraggableCardViews.FindAll(view => view.CardData.BaseCard.Id == id) : null;
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