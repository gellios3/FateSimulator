using Canvas.Aspects.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Popups.Signals.Activity;
using Services;
using Zenject;

/// <summary>
/// Global common installer for game scene
/// </summary>
public class CommonGameInstaller : MonoInstaller
{
        
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        InitActivitySignals();

        Container.DeclareSignal<ShowCardPopupSignal>(); 
        Container.DeclareSignal<ShowAspectPopupSignal>();
        Container.DeclareSignal<StartDragCardSignal>();
        Container.DeclareSignal<EndDragCardSignal>();

        Container.Bind<ShowAspectService>().AsSingle();
        Container.Bind<ConditionsService>().AsSingle();
        Container.Bind<ResultsService>().AsSingle();
        Container.Bind<CardDataService>().AsSingle().Lazy();
    }

    /// <summary>
    /// Init Activity signals
    /// </summary>
    private void InitActivitySignals()
    {
        Container.DeclareSignal<FindCardForActivitySignal>();
        Container.DeclareSignal<TryFindStartActivityCardsSignal>();
        Container.DeclareSignal<SetCardToCommonInventorySignal>();
        Container.DeclareSignal<InstallDraggableCardsSignal>();
    }
}