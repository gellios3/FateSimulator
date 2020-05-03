using Enums;
using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "New Aspect Obj", menuName = "Create Aspect Obj", order = 0)]
    public class BaseAspectObj : BaseObj, IBaseAspect
    {
        public ushort Id => id;

        public string aspectName;
        public string AspectName => aspectName;

        public string aspectDescription;
        public string AspectDescription => aspectDescription;

        public Sprite aspectImg;
        public Sprite AspectImg => aspectImg;

        public AspectType aspectType;
        public AspectType AspectType => aspectType;
        protected override void AddItemToDatabase()
        {
            byte index = 0;
            while (true)
            {
                if (index > 100)
                    break;
                index++;
                id = (ushort) (Random.value * 100000f);
                if (dataBase.IsUniqueId(id, GlobalType.Aspect))
                {
                    dataBase.allAspects.Add(this);
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