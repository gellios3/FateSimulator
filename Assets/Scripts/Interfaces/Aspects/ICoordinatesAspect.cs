using Cards.Models;
using Serializable.Cards;

namespace Interfaces.Aspects
{
    public interface ICoordinatesAspect : IBaseAspect
    {
        CardCoordinate Coordinate { get; }
    }
}