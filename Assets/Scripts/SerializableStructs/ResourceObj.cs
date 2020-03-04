using System;
using Enums.Aspects;
using Interfaces.Cards;

namespace SerializableStructs
{
    [Serializable]
    public struct ResourceObj: IResource
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;

        public MoneyType moneyType;
        public MoneyType MoneyType => moneyType;

        public ushort resourceValue;
        public ushort ResourceValue => resourceValue;
    }
}