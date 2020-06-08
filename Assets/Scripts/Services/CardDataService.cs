using System.Collections.Generic;
using Interfaces.Cards;
using Zenject;

namespace Services
{
    public class CardDataService
    {
        [Inject] private List<ICardData> CardDataList { get; }
    }
}