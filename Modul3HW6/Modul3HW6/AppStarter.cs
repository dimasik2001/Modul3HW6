using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modul3HW6.Configs;
using Modul3HW6.Services.Abstracts;
using Modul3HW6.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Modul3HW6
{
    public class AppStarter
    {
        private readonly ServiceProvider _serviceProvider;
        public AppStarter()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IBackUpService, BackUpService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            Starter = _serviceProvider.GetService<Starter>();
        }

        public Starter Starter { get; private set; }
    }
}
