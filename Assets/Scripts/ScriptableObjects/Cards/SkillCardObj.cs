using Enums.Skill;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "SkillCardObj", menuName = "Cards/Skill Card", order = 0)]
    public class SkillCardObj : BaseCardObj, ISkillCard
    {

        public RoutineSkillType routineSkillType;
        public RoutineSkillType RoutineSkillType => routineSkillType;

        public BattleSkillType battleSkillType;
        public BattleSkillType BattleSkillType => battleSkillType;
    }
}