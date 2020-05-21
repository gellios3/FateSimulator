using AbstractViews;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    /// <summary>
    /// Activities panel view
    /// </summary>
    public class ActivitiesPanelView : MonoBehaviour
    {
        [SerializeField] private StartActivityCardsView startActivityCardsView;
        [SerializeField] private ResultActivityCardsView resultActivityCardsView;

        private CustomButton StartActivityBtn { get; set; }
        private SignalBus SignalBus { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            startActivityCardsView.AllConditionsDone += OnAllCardsDone;
        }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="cardId"></param>
        /// <param name="customButton"></param>
        public void Init(IBaseActivity baseActivity, ushort cardId, CustomButton customButton)
        {
            StartActivityBtn = customButton;
            startActivityCardsView.Init(baseActivity, cardId);
        }
        
        /// <summary>
        /// On all conditions done
        /// </summary>
        private void OnAllCardsDone()
        {
            StartActivityBtn.Show();
        }
        
        /// <summary>
        /// On start activity
        /// </summary>
        public void OnStartActivity()
        {
            SignalBus.Fire(new StartActivitySignal
            {
                DropCardViews = startActivityCardsView.DropCardViews
            });
        }

        /// <summary>
        /// Show start activity cards
        /// </summary>
        public void ShowStartActivityCards()
        {
            startActivityCardsView.Show();
            resultActivityCardsView.Hide();
        }

        /// <summary>
        /// Show result cards
        /// </summary>
        public void ShowResultCards()
        {
            startActivityCardsView.Hide();
            resultActivityCardsView.Show();
            StartActivityBtn.Hide();
        }
        
    }
}