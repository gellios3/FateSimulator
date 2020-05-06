using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Actions cards service
    /// </summary>
    public class CardActionsService
    {
        [Inject] private CommonCardService CommonCardService { get; }

        /// <summary>
        /// Hide card by Id
        /// </summary>
        /// <param name="view"></param>
        public void HideCardById(IDraggableCardView view)
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
        /// <param name="value"></param>
        public void OnOutAreaById(ushort cardId, bool value)
        {
            GetCardById(cardId)?.OnOutArea.Invoke(value);
        }

        /// <summary>
        /// Call return back on start position by Id 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        public void ReturnBack(IDraggableCardView view, bool value = false)
        {
            view?.OnReturnBack.Invoke(value);
        }

        /// <summary>
        /// Call highlight card by Id
        /// </summary>
        /// <param name="cardId"></param>
        public void HighlightAllCardsById(ushort cardId)
        {
            foreach (var cardView in GetAllCardsById(cardId))
            {
                cardView.OnHighlight.Invoke();
            }
        }

        /// <summary>
        /// Get all cards by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        private IEnumerable<IDraggableCardView> GetAllCardsById(ushort cardId)
        {
            return CommonCardService.GetAllCardsById(cardId);
        } 

        /// <summary>
        /// Get card by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        private IDraggableCardView GetCardById(ushort cardId)
        {
            return CommonCardService.GetDraggableCardById(cardId);
        }
    }
}