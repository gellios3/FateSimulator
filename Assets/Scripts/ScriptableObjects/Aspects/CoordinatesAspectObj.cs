using Cards.Models;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "CoordinatesAspectObj", menuName = "Aspects/CoordinatesAspectObj", order = 0)]
    public class CoordinatesAspectObj : BaseAspectObj, ICoordinatesAspect
    {
        public CardCoordinate coordinate;
        public CardCoordinate Coordinate => coordinate;
    }
}