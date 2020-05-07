using Enums.Activities;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Cards
{
    [CreateAssetMenu(
        fileName = "WorkCardCondition",
        menuName = "Conditions/Requires/Card/WorkCardCondition",
        order = 0
    )]
    public class WorkCardConditionObj : ActivityCardConditionObj, IWorkCardCondition
    {
        public WorkType workType;
        public WorkType WorkType => workType;
    }
}