using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "New Aspect Obj", menuName = "Create Aspect Obj", order = 0)]
    public class BaseAspectObj : ScriptableObject, IBaseAspect
    {
        public ushort id;
        public ushort Id => id;

        public string aspectName;
        public string AspectName => aspectName;

        public string aspectDescription;
        public string AspectDescription => aspectDescription;

        public Sprite aspectImg;
        public Sprite AspectImg => aspectImg;

        public AspectType aspectType;
        public AspectType AspectType => aspectType;
    }
}