using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Common;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Actions cards service
    /// </summary>
    public class CardActionsService
    {
        [Inject] private CardViewsService CardViewsService { get; }

        /// <summary>
        /// Hide card by Id
        /// </summary>
        /// <param name="view"></param>
        public void HideCard(IDraggableCardView view)
        {
            view?.Hide();
        }

        /// <summary>
        /// Show card by Id
        /// </summary>
        /// <param name="view"></param>
        public void ShowCard(IDraggableCardView view)
        {
            view?.Show();
        }

        /// <summary>
        /// Call set card position by Id
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        public void SetCardPosition(IDraggableCardView view, Vector3 value)
        {
            view?.OnSetPosition.Invoke(value);
        }

        /// <summary>
        /// Call Drop card on Activity by Id 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        public void DropOnActivity(IDraggableCardView view, bool value)
        {
            view?.OnDropOnActivity.Invoke(value);
        }

        /// <summary>
        /// Call on drop by Id
        /// </summary>
        /// <param name="view"></param>
        public void CallOnDrop(IDraggableCardView view)
        {
            view?.OnDropCard.Invoke();
        }

        /// <summary>
        /// Call on out area by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="ownerId"></param>
        /// <param name="value"></param>
        public void OnOutAreaById(ushort cardId, ushort ownerId, bool value)
        {
            GetCardById(cardId, ownerId)?.OnOutArea.Invoke(value);
        }

        /// <summary>
        /// Call return back on start position by Id 
        /// </summary>
        /// <param name="view"></param>
        public void ReturnBack(IDraggableCardView view)
        {
            view?.OnReturnBack.Invoke();
        }

        /// <summary>
        /// Call highlight card by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="ownerId"></param>
        public void HighlightAllCardsById(ushort cardId, ushort ownerId)
        {
            foreach (var cardView in GetAllCardsById(cardId, ownerId))
            {
                if (StatusHelper.IsUseableStatus(cardView.TopCard.CurrentStatus.cardStatus))
                    cardView.OnHighlight.Invoke();
            }
        }

        /// <summary>
        /// Get all cards by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        private IEnumerable<IDraggableCardView> GetAllCardsById(ushort cardId, ushort ownerId)
        {
            return CardViewsService.GetAllCardsById(cardId, ownerId);
        }

        /// <summary>
        /// Get card by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        private IDraggableCardView GetCardById(ushort cardId, ushort ownerId)
        {
            return CardViewsService.GetDraggableCardById(cardId, ownerId);
        }
    }
}