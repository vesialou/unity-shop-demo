using Core;
using System;
using UnityEngine;
using VIP.Services;

namespace VIP.Actions
{
    [CreateAssetMenu(fileName = "SpendVIPTimeAction", menuName = "Actions/VIP/Spend VIP Time")]
    public class SpendVIPTimeAction : BaseActionScriptableObject
    {
        [SerializeField] private int _seconds = 60;

        public override bool CanApply(IActionFactory factory)
        {
            var vipService = factory.Resolve<VIPService>();
            return vipService.CanSpend(TimeSpan.FromSeconds(_seconds));
        }

        public override void Apply(IActionFactory factory)
        {
            var vipService = factory.Resolve<VIPService>();
            vipService.SpendVIPTime(TimeSpan.FromSeconds(_seconds));
        }
    }
}