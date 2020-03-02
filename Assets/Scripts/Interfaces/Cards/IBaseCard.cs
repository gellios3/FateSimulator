using System.Collections.Generic;
using Cards.Models;
using Enums;
using ScriptableObjects;
using UnityEngine;

namespace Interfaces.Cards
{
    public interface IBaseCard
    {
        ushort Id { get; }

        string CardName { get; }

        string ShortDescription { get; }

        CardCoordinate CardCoordinate { get; }

        CardType Type { get; }

        Sprite CardIcon { get; }

        List<BaseAspectObj> CardAspects { get; }
    }
}