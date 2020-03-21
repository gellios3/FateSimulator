using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Cards;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SaveGameObj", menuName = "GameSaveObj", order = 0)]
    public class GameSaveObj : ScriptableObject, ISaveGameObj
    {
        public List<BaseCardObj> cardList;
        public List<BaseCardObj> CardList => cardList;
    }
}