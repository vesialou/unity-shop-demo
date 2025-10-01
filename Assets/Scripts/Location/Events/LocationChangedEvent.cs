using Location.Data;

namespace Location.Events
{
    public class LocationChangedEvent
    {
        public LocationType NewLocation { get; }
        public LocationChangedEvent(LocationType newLocation)
        {
            NewLocation = newLocation;
        }
    }
}