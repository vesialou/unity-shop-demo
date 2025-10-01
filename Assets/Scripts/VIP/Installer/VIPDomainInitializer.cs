using System;
using VContainer.Unity;
using VIP.Services;

namespace VIP.Installer
{
    public class VIPDomainInitializer : IStartable
    {
        private readonly VIPService _vipService;

        public VIPDomainInitializer(VIPService vipService)
        {
            _vipService = vipService;
        }

        public void Start()
        {
            _vipService.Initialize();
        }
    }
}