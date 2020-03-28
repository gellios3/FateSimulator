using Canvas.Cards.Views;
using Interfaces.Cards;
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

        private void InstantiateCards()
        {
            Container.BindInstance(transform).AsTransient().WhenInjectedInto<CardDraggableSpawner>();
            Container.BindInterfacesAndSelfTo<CardDraggableSpawner>().AsSingle();  
            
            Container.BindInstance(cardViewParent).AsTransient().WhenInjectedInto<CardViewSpawner>();
            Container.Bind<CardViewSpawner>().AsSingle();
            
            Container.Bind<DraggableView>().AsSingle();
            Container.Bind<CardView>().AsSingle();
            
            Container.BindFactory<IBaseCard, DraggableView, DraggableView.Factory>().FromComponentInNewPrefab(cardPrefab);
            Container.BindFactory<IBaseCard, CardView, CardView.Factory>().FromComponentInNewPrefab(cardViewPrefab);
        }
    }
}