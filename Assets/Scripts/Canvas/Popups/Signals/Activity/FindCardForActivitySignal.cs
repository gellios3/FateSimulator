namespace Canvas.Popups.Signals.Activity
{
    public class FindCardForActivitySignal
    {
        
        public ushort ConditionId { get; }
        public ushort OwnerId { get; }
        
        public FindCardForActivitySignal(ushort conditionId, ushort ownerId)
        {
            ConditionId = conditionId;
            OwnerId = ownerId;
        }
    }
}