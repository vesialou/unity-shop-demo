using Core;
using Location.Data;
using Location.Services;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "SetLocationAction", menuName = "Actions/Location/Set Location")]
    public class SetLocationAction : BaseActionScriptableObject
    {
        [SerializeField] private LocationType _targetLocation = LocationType.MainSquare;

        public override bool CanApply(IActionFactory factory)
        {
            return true;
        }

        public override void Apply(IActionFactory factory)
        {
            var locationService = factory.Resolve<LocationDomainService>();
            locationService.SetLocation(_targetLocation);
        }
    }
}