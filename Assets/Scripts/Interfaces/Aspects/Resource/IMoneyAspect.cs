using Enums.Aspects;

namespace Interfaces.Aspects.Resource
{
    public interface IMoneyAspect : IResourceAspect
    {
        /// <summary>
        /// Money type
        /// </summary>
        MoneyType MoneyType { get; }
    }
}