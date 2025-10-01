using Core;
using Core.Events;
using Core.Services;
using Health.Data;

namespace Health.Services
{
    public class HealthService : ResourceService<HealthData, HealthChangedEvent>
    {
        public HealthService(PlayerData playerData,
                                EventBus eventBus) : base(playerData, eventBus)
        {
        }

        public int GetCurrentHealth()
        {
            return GetData().CurrentHealth;
        }

        public bool CanSpend(int amount)
        {
            return GetCurrentHealth() >= amount;
        }

        public void AddHealth(int amount)
        {
            GetData().CurrentHealth += amount;
            PublishEvents();
        }

        public void SpendHealth(int amount)
        {
            var data = GetData();
            if (data.CurrentHealth < amount)
            {
                return;
            }

            data.CurrentHealth -= amount;
            PublishEvents();
        }

        protected override HealthChangedEvent CreateChangedEvent(HealthData data)
        {
            return new HealthChangedEvent(data.CurrentHealth);
        }
    }
}