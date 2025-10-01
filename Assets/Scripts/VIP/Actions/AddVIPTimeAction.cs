using Core;
using System;
using UnityEngine;
using VIP.Services;

namespace VIP.Actions
{
    [CreateAssetMenu(fileName = "AddVIPTimeAction", menuName = "Actions/VIP/Add VIP Time")]
    public class AddVIPTimeAction : BaseActionScriptableObject
    {
        [SerializeField] private int _seconds = 60;

        public override bool CanApply(IActionFactory factory)
        {
            return true;
        }

        public override void Apply(IActionFactory factory)
        {
            var vipService = factory.Resolve<VIPService>();
            vipService.AddVIPTime(TimeSpan.FromSeconds(_seconds));
        }
    }
}