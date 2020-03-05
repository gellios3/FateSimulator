using System;
using Enums;
using Enums.Aspects;

namespace SerializableStructs.Activities
{
    [Serializable]
    public struct RequiredAspect
    {
        public AspectType aspectType;
    }
}