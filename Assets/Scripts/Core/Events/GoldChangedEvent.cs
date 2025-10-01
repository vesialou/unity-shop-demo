namespace Core.Events
{
    public class GoldChangedEvent
    {
        public int NewValue { get; }

        public GoldChangedEvent(int newValue)
        {
            NewValue = newValue;
        }
    }
}