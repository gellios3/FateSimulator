using Enums;
using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "New Aspect Obj", menuName = "Create Aspect Obj", order = 0)]
    public class BaseAspectObj : BaseObj, IBaseAspect
    {
        public string aspectName;
        public string AspectName => aspectName;

        public string aspectDescription;
        public string AspectDescription => aspectDescription;

        public Sprite aspectImg;
        public Sprite AspectImg => aspectImg;

        public AspectType aspectType;
        public AspectType AspectType => aspectType;
        
        protected override bool TryAddItemToDatabase()
        {
            if (!dataBase.IsUniqueId(id, GlobalType.Aspect)) 
                return false;
            dataBase.allAspects.Add(this);
            return true;
        }
        
        protected override void RemoveItemFromDatabase()
        {
            var index = dataBase.allAspects.FindIndex(item => item.id == id);
            if (index != -1)
            {
                dataBase.allAspects.RemoveAt(index);
            }
        }
    }
}