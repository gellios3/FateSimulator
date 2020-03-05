using Enums.Activities;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "WorkCardObj", menuName = "Cards/Work Card", order = 0)]
    public class WorkCardObj : BaseCardObj, IWorkCard
    {
        public WorkType workType;
        public WorkType WorkType => workType;
        
        public SkillCardObj requireSkill;
        public SkillCardObj RequireSkill => requireSkill;
    }
}