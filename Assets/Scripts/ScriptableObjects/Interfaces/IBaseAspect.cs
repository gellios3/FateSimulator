using Enums;
using UnityEngine;

namespace ScriptableObjects.Interfaces
{
    public interface IBaseAspect
    {
        ushort Id { get; }

        string AspectName { get; }

        Sprite AspectImg { get; }

        AspectType AspectType { get; }
    }
}