using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ScriptableObjects.Activities
{
    [CreateAssetMenu(fileName = "PossibleActivitiesListObj", menuName = "", order = 0)]
    public class PossibleActivitiesListObj : ScriptableObjectInstaller<PossibleActivitiesListObj>
    {
        public List<BaseActivityObj> possibleActivities;
        
        public override void InstallBindings()
        {
            Container.BindInstance(possibleActivities).IfNotBound();
        }
    }
}