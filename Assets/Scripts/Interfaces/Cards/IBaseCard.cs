using System.Collections.Generic;
using Enums;
using Interfaces.Aspects;
using ScriptableObjects;
using ScriptableObjects.Aspects;
using Serializable;
using UnityEngine;

namespace Interfaces.Cards
{
    /// <summary>
    /// Base card interface
    /// </summary>
    public interface IBaseCard : IBaseObj
    {
        string CardName { get; }
        string ShortDescription { get; }
        ushort MaxStackCount { get; }
        CardType Type { get; }
        Sprite CardIcon { get; }
        List<BaseAspectObj> AspectsList { get; }
        List<CardStatusPreset> StatusPresets { get; }
    }
}