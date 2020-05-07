using Enums;
using Interfaces.Conditions;
using Interfaces.Result;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "BaseResultObj", menuName = "", order = 0)]
    public class BaseResultObj : BaseObj, IBaseResult
    {

        public string title;
        public string Title => title;
        
        public byte level;
        public byte Level => level;

        public byte percent;
        public byte Percent => percent;
        
        protected override bool TryAddItemToDatabase()
        {
            if (!dataBase.IsUniqueId(id, GlobalType.Result)) 
                return false;
            dataBase.allResults.Add(this);
            return true;
        }
        
        protected override void RemoveItemFromDatabase()
        {
            var index = dataBase.allResults.FindIndex(item => item.id == id);
            if (index != -1)
            {
                dataBase.allResults.RemoveAt(index);
            }
        }
    }
}