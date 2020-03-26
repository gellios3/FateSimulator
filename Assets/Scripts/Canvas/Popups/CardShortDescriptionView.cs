using System;
using Canvas.Popups.Signals;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Popups
{
    public class CardShortDescriptionView : MonoBehaviour
    {
         readonly SignalBus _signalBus;

         private void Start()
         {
             _signalBus.Subscribe<ShowCardPopupSignal>(ShowCardPopupSignal);
         }

         public void ShowCardPopupSignal(ShowCardPopupSignal args)
         {
             Debug.LogError($"ShowCardPopupSignal {args.BaseCard.CardName}");
         }
    }
}