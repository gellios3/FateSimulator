using Enums;
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
                    case IMoneyCard resourceCard when sourceResult is IMoneyResult result:
                        if (resourceCard.ResourceType == result.ResourceType &&
                            resourceCard.MoneyType == result.MoneyType &&
                            resourceCard.ResourceValue == result.Value)
                            return cardObj;
                        break;
                    case ILessonCard lessonCard when sourceResult is ILessonResult result:
                        if (lessonCard.Type == CardType.Lesson &&
                            lessonCard.LessonType == result.LessonType &&
                            lessonCard.Level == result.Level)
                            return cardObj;
                        break;
                }
            }

            return null;
        }
    }
}