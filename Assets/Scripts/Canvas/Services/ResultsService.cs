using Interfaces.Cards;
using Interfaces.Result.Cards;
using ScriptableObjects;
using ScriptableObjects.Conditions.Results;
using Zenject;

namespace Canvas.Services
{
    /// <summary>
    /// Results service
    /// </summary>
    public class ResultsService
    {
        /// <summary>
        /// All items data base
        /// </summary>
        [Inject]
        private AllItemsDataBase DataBase { get; }

        /// <summary>
        /// Try find card by result obj
        /// </summary>
        /// <param name="sourceResult"></param>
        /// <returns></returns>
        public IBaseCard TryFindCardByResultObj(BaseResultObj sourceResult)
        {
            foreach (var cardObj in DataBase.allCards)
            {
                switch (cardObj)
                {
                    case IResourceCard resourceCard when sourceResult is IMoneyResult result:
                        if (resourceCard.Resource.resourceType == result.ResourceType &&
                            resourceCard.Resource.moneyType == result.MoneyType &&
                            resourceCard.Resource.resourceValue == result.Value)
                            return cardObj;
                        break;
                }
            }

            return null;
        }
    }
}