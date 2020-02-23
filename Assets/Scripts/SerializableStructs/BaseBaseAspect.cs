using System;
using Enums;
using ScriptableObjects.Interfaces;
using UnityEngine;

namespace SerializableStructs
{
    [Serializable]
    public class BaseBaseAspect : IBaseAspect
    {
        public ushort id;
        public ushort Id => id;
        
        public string aspectName;
        public string AspectName => aspectName;
        
        public Sprite aspectImg;
        public Sprite AspectImg => aspectImg;
        
        public AspectType aspectType;
        public AspectType AspectType => aspectType;
    }
}