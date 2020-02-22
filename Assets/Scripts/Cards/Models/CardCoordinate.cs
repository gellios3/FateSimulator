using System;
using UnityEngine;

namespace Cards.Models
{
    [Serializable]
    public struct CardCoordinate
    {
        public Vector2 terrainPos;

        public Vector2 globalPos;
    }
}