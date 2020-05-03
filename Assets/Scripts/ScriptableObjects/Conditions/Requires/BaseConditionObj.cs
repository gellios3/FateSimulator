using Enums;
using Interfaces.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public class BaseConditionObj : BaseObj, IBaseCondition
    {
        public byte level;
        public byte Level => level;

        public string title;
        public string Title => title;
        protected override void AddItemToDatabase()
        {
            byte index = 0;
            while (true)
            {
                if (index > 100)
                    break;
                index++;
                id = (ushort) (Random.value * 100000f);
                if (dataBase.IsUniqueId(id, GlobalType.Condition))
                {
                    dataBase.allConditions.Add(this);
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}