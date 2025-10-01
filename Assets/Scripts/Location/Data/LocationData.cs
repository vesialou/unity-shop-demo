namespace Location.Data
{
    public class LocationData
    {
        public LocationType CurrentLocation { get; set; } = LocationType.Forest;
        public LocationType DefaultLocation { get; } = LocationType.Forest;
    }
}