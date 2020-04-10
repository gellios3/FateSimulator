using System;
using Enums;
using UnityEngine;

namespace Serializable.Common
{
    [Serializable]
    public struct ColorPreset
    {
        public Status status;
        
        public Color color;
    }
}