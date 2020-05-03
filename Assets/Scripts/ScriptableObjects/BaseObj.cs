using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public abstract class BaseObj : ScriptableObject
    {
        public ushort id;
        public AllItemsDataBase dataBase;
        
        public void Awake()
        {
            if (id != 0 || dataBase == null) 
                return;
            AddItemToDatabase();
        }

        private void OnValidate()
        {
            if (id != 0 || dataBase == null) 
                return;
            AddItemToDatabase();
        }

        protected abstract void AddItemToDatabase();

        private void OnDestroy()
        {
            if (dataBase == null) 
                return;
            var index = dataBase.allCards.FindIndex(card => card.id == id);
            if (index != -1)
            {
                dataBase.allCards.RemoveAt(index);
            }
        }
    }
}