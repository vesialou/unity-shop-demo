using Core;
using Core.Services;
using Location.Data;
using Location.Events;

namespace Location.Services
{
    public class LocationDomainService : ResourceService<LocationData, LocationChangedEvent>
    {

        public LocationDomainService(PlayerData playerData, EventBus eventBus) : base(playerData, eventBus)
        {
        }

        public LocationType GetCurrentLocation()
        {
            return GetData().CurrentLocation;
        }

        public void SetLocation(LocationType location)
        {
            var data = GetData();
            data.CurrentLocation = location;
            PublishEvents();
        }

        public void ResetToDefault()
        {
            var data = GetData();
            SetLocation(data.DefaultLocation);
        }

        protected override LocationChangedEvent CreateChangedEvent(LocationData data)
        {
            return new LocationChangedEvent(data.CurrentLocation);
        }
    }
}