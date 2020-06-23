using Canvas.Cards.Services;
using Canvas.Cards.Views;
using Interfaces.Cards;
using UnityEngine.EventSystems;
using Zenject;

namespace AbstractViews
{
    public class NonDraggableAreaView : BaseView, IPointerEnterHandler, IPointerExitHandler
    {
        private ICardData tempCardId;

        [Inject] private CardActionsService CardActionsService { get; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            var draggableView = eventData.pointerDrag.GetComponent<DraggableCardView>();
            if (draggableView == null)
                return;
            tempCardId = draggableView.CardData;
            CardActionsService.OnOutAreaById(tempCardId.BaseCard.Id, tempCardId.InventoryData.OwnerId, true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (tempCardId != null)
                CardActionsService.OnOutAreaById(tempCardId.BaseCard.Id, tempCardId.InventoryData.OwnerId, false);
        }
    }
}