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
        /// <param name="cardId"></param>
        public void HideCardById(ushort cardId)
        {
            GetCardById(cardId)?.Hide();
        }

        /// <summary>
        /// Show card by Id
        /// </summary>
        /// <param name="cardId"></param>
        public void ShowCardById(ushort cardId)
        {
            GetCardById(cardId)?.Show();
        }

        /// <summary>
        /// Call set card position by Id
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="value"></param>
        public void SetCardPositionById(ushort cardId, Vector3 value)
        {
            GetCardById(cardId)?.OnSetPosition.Invoke(value);
        }

        /// <summary>
        /// Call Drop card on Activity by Id 
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="value"></param>
        public void DropOnActivityById(ushort cardId, bool value)
        {
            GetCardById(cardId)?.OnDropOnActivity.Invoke(value);
        }

        /// <summary>
        /// Call on drop by Id
        /// </summary>
        /// <param name="cardId"></param>
        public void OnDropById(ushort cardId)
        {
            GetCardById(cardId)?.OnDropCard.Invoke();
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
        /// <param name="cardId"></param>
        /// <param name="value"></param>
        public void ReturnBackById(ushort cardId, bool value = false)
        {
            GetCardById(cardId)?.OnReturnBack.Invoke(value);
        }

        /// <summary>
        /// Call highlight card by Id
        /// </summary>
        /// <param name="cardId"></param>
        public void HighlightCardById(ushort cardId)
        {
            GetCardById(cardId)?.OnHighlight.Invoke();
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