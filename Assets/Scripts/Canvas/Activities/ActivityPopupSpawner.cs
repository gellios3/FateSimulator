using System.Collections.Generic;
using Canvas.Activities.Services;
using Canvas.Activities.Views;
using Canvas.Popups.Views.ActivityPopup;
using UnityEngine;
using Zenject;

namespace Canvas.Activities
{
    public class ActivityPopupSpawner : IInitializable
    {
        [Inject] private Transform PopupsParent { get; }
        [Inject] private List<ActivityView> ActivityViews { get; }
        [Inject] private ActivityViewsService ActivityViewsService { get; }

        private readonly BaseActivityPopupView.Factory baseActivityPopupFactory;

        public ActivityPopupSpawner(BaseActivityPopupView.Factory baseActivityPopupFactory)
        {
            this.baseActivityPopupFactory = baseActivityPopupFactory;
        }

        public void Initialize()
        {
            foreach (var view in ActivityViews)
            {
                var cardGameObject = baseActivityPopupFactory.Create(view);
                cardGameObject.transform.parent = PopupsParent;
                cardGameObject.Hide();
                ActivityViewsService.AddActivityView(view, cardGameObject);
            }
        }
    }
}