using AbstractViews;
using Canvas.Popups.Signals;
using Interfaces.Aspects;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Aspect popup
    /// </summary>
    public class AspectDescriptionPopupView : BaseView
    {
        #region Parameters
        
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Button closeBtn;

        private IBaseAspect BaseAspect { get; set; }
        private SignalBus SignalBus { get; set; }
        [Inject] private AllItemsDataBase AllItemsDataBase { get; }
        
        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            Hide();
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowAspectPopupSignal>(OnShowAspectPopup);
            
            closeBtn.onClick.AddListener(Hide);
        }

        /// <summary>
        /// Show Aspect popup
        /// </summary>
        /// <param name="signal"></param>
        private void OnShowAspectPopup(ShowAspectPopupSignal signal)
        {
            BaseAspect = AllItemsDataBase.GetAspectById(signal.AspectId);

            title.text = BaseAspect.AspectName;
            description.text = BaseAspect.AspectDescription;
            icon.sprite = BaseAspect.AspectImg;
            Show();
        }
    }
}