namespace Core.Events
{
    public class PurchaseProcessingStateChangedEvent
    {
        public bool IsProcessing { get; }

        public PurchaseProcessingStateChangedEvent(bool isProcessing)
        {
            IsProcessing = isProcessing;
        }
    }
}