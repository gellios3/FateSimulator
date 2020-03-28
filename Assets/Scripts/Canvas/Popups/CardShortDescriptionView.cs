using Canvas.Popups.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups
{
    public class CardShortDescriptionView : MonoBehaviour
    {
        private SignalBus SignalBus { get; set; }
         
         [Inject]
         public void Construct(SignalBus signalBus){
             Debug.LogError("Construct");
             SignalBus = signalBus;
             SignalBus.Subscribe<ShowCardPopupSignal>(ShowCardPopupSignal);
         }

         public void ShowCardPopupSignal(ShowCardPopupSignal args)
         {
             Debug.LogError($"ShowCardPopupSignal {args.BaseCard.CardName}");
         }


    }
}