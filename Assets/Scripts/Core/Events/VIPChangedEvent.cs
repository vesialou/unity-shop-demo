namespace Core.Events
{
    public class VIPChangedEvent
    {
        public int Seconds { get; }
        public VIPChangedEvent(int seconds) => Seconds = seconds;
    }
}