using System.Collections.Generic;
using AbstractViews;
using Cards.Views;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace Cards.Installers
{
    public class CardsInstaller : MonoInstaller
    {
        [Inject] private List<BaseCardObj> CardList { get; }

        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject cardViewPrefab;
        
        [SerializeField] private Transform cardViewParent;

        public override void InstallBindings()
        {
            Debug.LogError($"CardList {CardList.Count}");
            InstantiateCards();
        }

        public void InstantiateCards()
        {
            foreach (var cardObj in CardList)
            {
                var cardGameObject = Instantiate(cardPrefab, transform);
                cardGameObject.transform.localPosition = new Vector3(cardObj.PosOnTable.x, cardObj.PosOnTable.y, -3);
                var draggableCard = cardGameObject.GetComponent<DraggableView>();
                var topCardObject = Instantiate(cardViewPrefab, cardViewParent);
                draggableCard.SetCardView(topCardObject.GetComponent<CardView>(), cardObj);
            }
        }
    }
}