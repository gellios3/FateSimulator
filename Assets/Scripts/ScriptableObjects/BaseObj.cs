using Interfaces;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public abstract class BaseObj : ScriptableObject, IBaseObj
    {
        public ushort id;
        public ushort Id => id;
        
        public AllItemsDataBase dataBase;
        public AllItemsDataBase DataBase => dataBase;
        
        public void Awake()
        {
            if (id != 0 || dataBase == null) 
                return;
            RecursiveAddItem();
        }

        private void OnValidate()
        {
            if (id != 0 || dataBase == null) 
                return;
            RecursiveAddItem();
        }

        protected abstract bool TryAddItemToDatabase();
        protected abstract void RemoveItemFromDatabase();

        private void RecursiveAddItem()
        {
            byte index = 0;
            while (true)
            {
                if (index > 100)
                    break;
                index++;
                id = (ushort) (Random.value * 100000f);
                if (!TryAddItemToDatabase())
                    continue;
                break;
            }
        }

        private void OnDestroy()
        {
            if (dataBase == null) 
                return;
            RemoveItemFromDatabase();
        }
    }
}