namespace Core.Events
{
    public class HealthChangedEvent
    {
        public int NewValue { get; }
        public HealthChangedEvent(int newValue) => NewValue = newValue;
    }
}