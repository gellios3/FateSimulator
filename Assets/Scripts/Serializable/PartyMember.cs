using System;
using Interfaces;

namespace Serializable
{
    [Serializable]
    public class PartyMember : IPartyMember
    {
        public ushort id;
        public ushort Id => id;
        public string name;
        public string Name => name;
        public ushort level;
        public ushort Level => level;
        public ushort hp;
        public ushort Hp => hp;
        public ushort xp;
        public ushort Xp => xp;
    }
}