using System.Collections.Generic;
using Activities.Installers;
using Interfaces;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SaveGameObj", menuName = "GameSaveObj", order = 0)]
    public class GameSaveObj : ScriptableObjectInstaller<GameSaveObj>, ISaveGameObj
    {
        public List<BaseCardObj> cardList;
        public List<BaseCardObj> CardList => cardList;

        public override void InstallBindings()
        {
            Container.BindInstance(CardList).IfNotBound();
        }
    }
}