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
        /// <summary>
        /// Active card list
        /// </summary>
        public List<BaseCardObj> cardList;
        public List<BaseCardObj> CardList => cardList;
        
        /// <summary>
        /// All Items Data Base
        /// </summary>
        public AllItemsDataBase dataBase;
        public AllItemsDataBase DataBase => dataBase;

        /// <summary>
        /// Install bindings
        /// </summary>
        public override void InstallBindings()
        {
            Container.BindInstance(CardList).IfNotBound();
            Container.BindInstance(DataBase).IfNotBound();
        }
    }
}