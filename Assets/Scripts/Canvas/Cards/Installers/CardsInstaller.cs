using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Views;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Installers
{
    /// <summary>
    /// Card installer
    /// </summary>
    public class CardsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject cardViewPrefab;

        [SerializeField] private Transform cardViewParent;

        public override void InstallBindings()
        {
            Container.Bind<CardViewsService>().AsSingle(); 
            Container.Bind<CardSignalsService>().AsSingle();
            Container.Bind<CardActionsService>().AsSingle();

            Container.Bind<CardAppearanceService>().AsTransient();
            Container.Bind<DraggableCardService>().AsTransient();

            InstantiateCards();
        }

        private void InstantiateCards()
        {
            Container.BindInstance(transform).AsTransient().WhenInjectedInto<CardDraggableSpawner>();
            Container.BindInterfacesAndSelfTo<CardDraggableSpawner>().AsSingle();

            Container.BindInstance(cardViewParent).AsTransient().WhenInjectedInto<CardViewSpawner>();
            Container.Bind<CardViewSpawner>().AsSingle();

            Container.BindFactory<IBaseCard, ICardView, DraggableCardView, DraggableCardView.Factory>()
                .FromComponentInNewPrefab(cardPrefab);
            Container.BindFactory<IBaseCard, CardView, CardView.Factory>().FromComponentInNewPrefab(cardViewPrefab);
        }
    }
}