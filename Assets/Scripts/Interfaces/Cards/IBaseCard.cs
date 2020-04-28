﻿using System.Collections.Generic;
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
    public interface IBaseCard
    {
        ushort Id { get; }
        byte Level { get; }
        Vector2 PosOnTable { get; }
        string CardName { get; }
        string ShortDescription { get; }
        CardType Type { get; }
        Sprite CardIcon { get; }
        List<BaseAspectObj> AspectsList { get; }
        List<CardStatusPreset> StatusPresets { get; }
    }
}