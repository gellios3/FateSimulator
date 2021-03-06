﻿using System;
using Enums.Aspects;
using Interfaces.Aspects;
using ScriptableObjects;
using UnityEngine;

namespace Serializable.Aspects
{
    /// <summary>
    /// Base aspect
    /// </summary>
    [Serializable]
    public class BaseAspect : IBaseAspect
    {
        public ushort Id { get; }
        public AllItemsDataBase DataBase { get; }
        public string AspectName { get; }
        public string AspectDescription { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }

        public BaseAspect(IBaseAspect aspect)
        {
            Id = aspect.Id;
            DataBase = aspect.DataBase;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            AspectDescription = aspect.AspectDescription;
        }
    }
}