using Enums;
using Enums.Activities;
using Enums.Skill;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Cards
{
    [CreateAssetMenu(fileName = "SkillCardCondition", menuName = "Conditions/Requires/Card/SkillCardCondition",
        order = 0)]
    public class SkillCardCondition : CardConditionObj, ISkillCardCondition
    {
        public RoutineSkillType routineSkillType;
        public RoutineSkillType RoutineSkillType => routineSkillType;

        public BattleSkillType battleSkillType;
        public BattleSkillType BattleSkillType => battleSkillType;

        public ActivityType activityType;
        public ActivityType ActivityType => activityType;

        public CardStatus onEndActivityStatus;
        public CardStatus OnEndActivityStatus => onEndActivityStatus;
    }
}