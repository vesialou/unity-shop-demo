using System.Collections.Generic;

namespace Location.Data
{
    public static class LocationDisplayNames
    {
        private static readonly Dictionary<LocationType, string> _names = new()
        {
            { LocationType.MainSquare, "Главная площадь" },
            { LocationType.Forest, "Лес" },
            { LocationType.Dungeon, "Подземелье" },
            { LocationType.Castle, "Замок" }
        };

        public static string GetDisplayName(LocationType locationType)
        {
            return _names.TryGetValue(locationType, out var name) ? name : locationType.ToString();
        }
    }
}