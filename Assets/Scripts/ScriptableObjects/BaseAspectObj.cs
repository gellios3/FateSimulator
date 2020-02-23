using Enums;
using ScriptableObjects.Interfaces;
using SerializableStructs;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Aspect Obj", menuName = "Create Aspect Obj", order = 0)]
    public class BaseAspectObj : ScriptableObject, IBaseAspect
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