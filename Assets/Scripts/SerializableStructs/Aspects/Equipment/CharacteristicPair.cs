using System;
using Enums.Aspects;

namespace SerializableStructs.Aspects.Equipment
{
    [Serializable]
    public struct CharacteristicPair
    {
        public CharacteristicType type;
        public byte value;
    }
}