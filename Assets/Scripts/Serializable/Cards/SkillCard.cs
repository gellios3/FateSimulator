using System;
using Enums.Skill;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class SkillCard : BaseCard, ISkillCard
    {
        public byte Level { get; }
        public RoutineSkillType RoutineSkillType { get; }
        public BattleSkillType BattleSkillType { get; }
        
        public SkillCard(ISkillCard cardObj) : base(cardObj)
        {
            Level = cardObj.Level;
            RoutineSkillType = cardObj.RoutineSkillType;
            BattleSkillType = cardObj.BattleSkillType;
        }
        
    }
}