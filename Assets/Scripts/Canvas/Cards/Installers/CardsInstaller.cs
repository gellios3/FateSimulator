using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards.Views;
using Interfaces.Cards;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Installers
{
    public class CardsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject cardViewPrefab;

        [SerializeField] private Transform cardViewParent;

        public override void InstallBindings()
        {
            InstantiateCards();
        }

        public void InstantiateCards()
        {
            Container.BindInterfacesTo<CardDraggableSpawner>().AsSingle();
            Container.Bind<DraggableView>().AsSingle();
            Container.BindFactory<IBaseCard, DraggableView, DraggableView.Factory>()
                .FromComponentInNewPrefab(cardPrefab);
        }
    }
}