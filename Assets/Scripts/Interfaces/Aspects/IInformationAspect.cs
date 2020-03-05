using UnityEngine;

namespace Interfaces.Aspects
{
    public interface IInformationAspect : IBaseAspect
    {
        string PopupDescription { get; }
        Sprite PopupImg { get; }
    }
}