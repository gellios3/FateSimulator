using System;
using UnityEngine;

namespace Serializable.Cards
{
    [Serializable]
    public struct CardCoordinate
    {
        public Vector2 terrainPos;

        public Vector2 globalPos;
    }
}