using Canvas.Cards.Signals;
using Zenject;

namespace AbstractViews
{
    public class StartGameCommonView : BaseView
    {
        private SignalBus SignalBus { get; set; }
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        private void Start()
        {
            Invoke(nameof(CallSetCards),0.5f);
        }

        private void CallSetCards()
        {
            SignalBus.Fire(new InstallDraggableCardsSignal());
        }
    }
}