using Interfaces.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "BaseRequireObj", menuName = "", order = 0)]
    public class BaseRequireObj : ScriptableObject, IBaseRequire
    {
        public byte level;
        public byte Level => level;
    }
}