using System.Collections.Generic;
using Activities.Services;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        // [Inject] private List<BaseCardObj> CardList { get; }
        
        public override void InstallBindings()
        {
            // Debug.LogError($"CardList {CardList.Count}");
            Container.Bind<ActivitiesService>().AsSingle();
        }

    }
}
