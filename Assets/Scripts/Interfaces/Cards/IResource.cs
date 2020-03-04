using Enums.Aspects;

namespace Interfaces.Cards
{
    public interface IResource 
    {
        /// <summary>
        /// Resource type
        /// </summary>
        ResourceType ResourceType { get; }
        
        /// <summary>
        /// Money type
        /// </summary>
        MoneyType MoneyType { get; }
        
        /// <summary>
        /// Resource value
        /// </summary>
        ushort ResourceValue { get; }
    }
}