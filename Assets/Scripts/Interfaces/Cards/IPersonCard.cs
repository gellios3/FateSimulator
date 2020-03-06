using Enums.Aspects;
using Enums.Person;

namespace Interfaces.Cards
{
    public interface IPersonCard : IBaseCard
    {
        PersonType PersonType { get; }
        
        PersonStatus PersonStatus { get; } 
    }
}