using Interfaces.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "BaseResultObj", menuName = "", order = 0)]
    public class BaseResultObj : ScriptableObject, IBaseResult
    {
        public byte level;
        public byte Level => level;

        public byte percent;
        public byte Percent => percent;
    }
}