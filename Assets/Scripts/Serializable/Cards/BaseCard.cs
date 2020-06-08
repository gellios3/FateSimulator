﻿using System;
using System.Collections.Generic;
using Enums;
using Interfaces.Aspects;
using Interfaces.Cards;
using ScriptableObjects;
using ScriptableObjects.Aspects;
using UnityEngine;

namespace Serializable.Cards
{
    [Serializable]
    public class BaseCard : IBaseCard
    {
        public ushort Id { get; }
        public AllItemsDataBase DataBase { get; }
        public byte Level { get; }
        public string CardName { get; }
        public string ShortDescription { get; }
        public CardType Type { get; }
        public Sprite CardIcon { get; }
        public List<BaseAspectObj> AspectsList { get; }
        public List<CardStatusPreset> StatusPresets { get; }

        public BaseCard(IBaseCard cardObj)
        {
            Id = cardObj.Id;
            DataBase = cardObj.DataBase;
            Level = cardObj.Level;
            CardName = cardObj.CardName;
            ShortDescription = cardObj.ShortDescription;
            Type = cardObj.Type;
            CardIcon = cardObj.CardIcon;
            AspectsList = cardObj.AspectsList;
            StatusPresets = cardObj.StatusPresets;
        }
    }
}