using System;
using Enums.Activities;
using Interfaces.Cards;
using ScriptableObjects.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class WorkCard : BaseCard, IWorkCard
    {
        public WorkType WorkType { get; }
        public SkillCardObj RequireSkill { get; }

        public WorkCard(IWorkCard cardObj) : base(cardObj)
        {
            WorkType = cardObj.WorkType;
            RequireSkill = cardObj.RequireSkill;
        }
    }
}