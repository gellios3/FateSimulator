using System;
using Enums;
using UnityEngine;

namespace Serializable
{
    [Serializable]
    public class CardStatusPreset
    {
        public CardStatus cardStatus;
        public ushort duration;
        public Color color;
    }
}