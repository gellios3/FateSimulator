using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public abstract class BaseObj : ScriptableObject
    {
        public ushort id;
        public AllCardsDataBase dataBase;
        
        public void Awake()
        {
            if (id != 0 || dataBase == null) 
                return;
            AddCardToDatabase();
        }

        private void OnValidate()
        {
            if (id != 0 || dataBase == null) 
                return;
            AddCardToDatabase();
        }

        protected abstract void AddCardToDatabase();

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