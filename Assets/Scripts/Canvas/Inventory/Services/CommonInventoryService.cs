using Canvas.Inventory.Signals;
using Zenject;

namespace Canvas.Inventory.Services
{
    public class CommonInventoryService : BaseInventoryService
    {
        public CommonInventoryService(SignalBus signalBus)
        {
            signalBus.Subscribe<SetCardToCommonInventorySignal>(SetCardToCommonInventory);
        }

        /// <summary>
        /// Set common cards 
        /// </summary>
        /// <param name="signal"></param>
        private void SetCardToCommonInventory(SetCardToCommonInventorySignal signal)
        {
            SetCardToInventory(signal.SourceView);
        }
        
    }
}