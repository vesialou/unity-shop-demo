using Core;
using Core.Events;
using Core.Services;
using Gold.Data;
using UnityEngine;

namespace Gold.Services
{
    public class GoldService : ResourceService<GoldData, GoldChangedEvent>
    {

        public GoldService(PlayerData playerData, EventBus eventBus) : base(playerData, eventBus)
        {
        }

        public int GetCurrentGold()
        {
            return GetData().CurrentGold;
        }

        public bool CanSpend(int amount)
        {
            return GetCurrentGold() >= amount;
        }

        public void AddGold(int amount)
        {
            var data = GetData();
            data.CurrentGold += amount;
            PublishEvents();
        }

        public void SpendGold(int amount)
        {
            var data = GetData();
            if (data.CurrentGold < amount)
            {
                Debug.LogError($"Not enough gold: have {data.CurrentGold}, need {amount}");
                return;
            }

            data.CurrentGold -= amount;
            PublishEvents();
        }

        protected override GoldChangedEvent CreateChangedEvent(GoldData data)
        {
            return new GoldChangedEvent(data.CurrentGold);
        }
    }
}