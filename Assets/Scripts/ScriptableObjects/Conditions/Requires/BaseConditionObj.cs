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
        
        protected override bool TryAddItemToDatabase()
        {
            if (!dataBase.IsUniqueId(id, GlobalType.Condition)) 
                return false;
            dataBase.allConditions.Add(this);
            return true;
        }
        
        protected override void RemoveItemFromDatabase()
        {
            var index = dataBase.allConditions.FindIndex(item => item.id == id);
            if (index != -1)
            {
                dataBase.allConditions.RemoveAt(index);
            }
        }
    }
}