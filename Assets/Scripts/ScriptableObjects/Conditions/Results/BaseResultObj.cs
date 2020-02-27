using UnityEngine;

namespace ScriptableObjects.Results
{
    [CreateAssetMenu(fileName = "BaseResultObj", menuName = "", order = 0)]
    public class BaseResultObj : ScriptableObject
    {
        public byte level;
        public byte percent;
    }
}