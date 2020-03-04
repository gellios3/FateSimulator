using Cards.Models;

namespace Interfaces.Aspects
{
    public interface ICoordinatesAspect : IBaseAspect
    {
        CardCoordinate Coordinate { get; }
    }
}