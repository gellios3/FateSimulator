using System.Collections.Generic;
using Interfaces;
using Interfaces.Cards;
using Serializable;
using Serializable.Cards;
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
        /// Card data list
        /// </summary>
        public List<CardData> cardDataList;
        public List<ICardData> CardDataList { get; private set; } 

        /// <summary>
        /// Party members
        /// </summary>
        public List<PartyMember> partyMembers;
        public List<IPartyMember> PartyMembers { get; private set; } 
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
            CardDataList = new List<ICardData>(cardDataList);
            PartyMembers = new List<IPartyMember>(partyMembers);
            
            Container.BindInstance(CardDataList).IfNotBound();
            Container.BindInstance(DataBase).IfNotBound();
            Container.BindInstance(PartyMembers).IfNotBound();
        }
    }
}