using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace ScriptableObjects
{
    /// <summary>
    /// Game save obj
    /// </summary>
    [CreateAssetMenu(fileName = "SaveGameObj", menuName = "", order = 0)]
    public class GameSaveObj : ScriptableObjectInstaller<GameSaveObj>, ISaveGameObj
    {
        public List<BaseCardObj> cardList;
        public List<BaseCardObj> CardList => cardList;
        
        public AllItemsDataBase dataBase;
        public AllItemsDataBase DataBase => dataBase;

        public override void InstallBindings()
        {
            Container.BindInstance(CardList).IfNotBound();
            Container.BindInstance(DataBase).IfNotBound();
        }
    }
}