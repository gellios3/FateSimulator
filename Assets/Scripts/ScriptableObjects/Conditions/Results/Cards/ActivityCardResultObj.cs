﻿using Enums.Activities;
using Interfaces.Result.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results.Cards
{
    [CreateAssetMenu(fileName = "ActivityCardCondition", menuName = "Conditions/Results/Card/ActivityCardCondition",
        order = 0)]
    public class ActivityCardResultObj : CardResultObj, IActivityCardResult
    {
        public ActivityType activityType;
        public ActivityType ActivityType => activityType;
    }
}