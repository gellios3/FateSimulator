using System.Collections.Generic;
using Enums;
using ScriptableObjects;
using ScriptableObjects.Aspects;
using UnityEngine;

namespace Interfaces.Cards
{
    public interface IBaseCard
    {
        ushort Id { get; }

        string CardName { get; }

        string ShortDescription { get; }

        CardType Type { get; }

        Sprite CardIcon { get; }

        List<BaseAspectObj> AspectsList { get; }
    }
}