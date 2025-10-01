using Core.Events;

namespace Core.Services
{
    public abstract class ResourceService<TData, TChangedEvent>
        where TData : class, new()
        where TChangedEvent : class
    {
        protected readonly PlayerData PlayerData;
        protected readonly EventBus EventBus;

        protected ResourceService(PlayerData playerData, EventBus eventBus)
        {
            PlayerData = playerData;
            EventBus = eventBus;
        }

        protected TData GetData() => PlayerData.Get<TData>();

        public virtual void Initialize()
        {
            PublishEvents();
        }

        public void PublishCurrentState()
        {
            var changedEvent = CreateChangedEvent(GetData());
            EventBus.Publish(changedEvent);
        }

        protected void PublishEvents()
        {
            var data = GetData();
            var changedEvent = CreateChangedEvent(data);
            EventBus.Publish(changedEvent);
            EventBus.Publish(new ResourcesChangedEvent());
        }

        protected abstract TChangedEvent CreateChangedEvent(TData data);
    }
}