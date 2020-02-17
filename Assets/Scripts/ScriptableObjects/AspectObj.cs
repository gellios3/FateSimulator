using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Aspect Obj", menuName = "Create Aspect Obj", order = 0)]
    public class AspectObj : ScriptableObject
    {
        public ushort id;

        public string aspectName;

        public Sprite aspectImg;
    }
}