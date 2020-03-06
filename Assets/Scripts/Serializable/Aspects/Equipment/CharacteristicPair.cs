using System;
using Enums.Aspects;

namespace Serializable.Aspects.Equipment
{
    [Serializable]
    public struct CharacteristicPair
    {
        public CharacteristicType type;
        public byte value;
    }
}