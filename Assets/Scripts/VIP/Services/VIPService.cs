using Core;
using Core.Events;
using Core.Services;
using System;
using UnityEngine;
using VIP.Data;

namespace VIP.Services
{
    public class VIPService : ResourceService<VIPData, VIPChangedEvent>
    {

        public VIPService(PlayerData playerData, EventBus eventBus) : base(playerData, eventBus)
        {
        }

        public TimeSpan GetVIPDuration()
        {
            return GetData().VIPDuration;
        }

        public int GetVIPDurationInSeconds()
        {
            return (int)GetVIPDuration().TotalSeconds;
        }

        public bool CanSpend(TimeSpan duration)
        {
            return GetVIPDuration() >= duration;
        }

        public void AddVIPTime(TimeSpan duration)
        {
            var data = GetData();
            data.VIPDuration += duration;
            PublishEvents();
        }

        public void SpendVIPTime(TimeSpan duration)
        {
            var data = GetData();

            if (data.VIPDuration < duration)
            {
                Debug.LogWarning($"Not enough VIP time: {data.VIPDuration.TotalSeconds}s < {duration.TotalSeconds}s");
                return;
            }

            data.VIPDuration -= duration;
            PublishEvents();
        }

        public void ResetVIPTime()
        {
            var data = GetData();
            data.VIPDuration = TimeSpan.Zero;
            PublishEvents();
        }

        protected override VIPChangedEvent CreateChangedEvent(VIPData data)
        {
            return new VIPChangedEvent((int)data.VIPDuration.TotalSeconds);
        }
    }
}