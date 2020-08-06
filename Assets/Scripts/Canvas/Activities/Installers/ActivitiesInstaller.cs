using System.Collections.Generic;
using Canvas.Activities.Interfaces;
using Canvas.Activities.Services;
using Canvas.Activities.Views;
using Canvas.Popups.Views.ActivityPopup;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject activityPopupPrefab;

        [SerializeField] private Transform popupsParent;

        [SerializeField] private List<ActivityView> activityViews;

        public override void InstallBindings()
        {
            Container.Bind<ActivityViewsService>().AsSingle();
            // Install Lazy service 
            Container.Bind<ActivityService>().AsTransient().Lazy();
            Container.Bind<RunActivityService>().AsTransient().Lazy();

            InstallActivityPopups();
        }

        private void InstallActivityPopups()
        {
            Container.BindInstance(popupsParent).AsTransient().WhenInjectedInto<ActivityPopupSpawner>();
            Container.BindInstance(activityViews).AsTransient().WhenInjectedInto<ActivityPopupSpawner>();
            Container.BindInterfacesAndSelfTo<ActivityPopupSpawner>().AsSingle();

            Container.BindFactory<IActivityView, BaseActivityPopupView, BaseActivityPopupView.Factory>()
                .FromComponentInNewPrefab(activityPopupPrefab);
        }
    }
}