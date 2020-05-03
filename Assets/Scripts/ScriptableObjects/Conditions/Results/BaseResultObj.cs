using Enums;
using Interfaces.Conditions;
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
        protected override void AddItemToDatabase()
        {
            byte index = 0;
            while (true)
            {
                if (index > 100)
                    break;
                index++;
                id = (ushort) (Random.value * 100000f);
                if (dataBase.IsUniqueId(id, GlobalType.Result))
                {
                    dataBase.allResults.Add(this);
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