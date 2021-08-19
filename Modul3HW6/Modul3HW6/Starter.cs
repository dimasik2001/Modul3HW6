using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modul3HW6.Configs;
using Modul3HW6.Services.Abstracts;

namespace Modul3HW6
{
    public class Starter
    {
        private readonly ILogger _logger;
        private readonly IBackUpService _backUpService;

        public Starter(ILogger logger, IBackUpService backUpService, IConfigService configService)
        {
            _logger = logger;
            _backUpService = backUpService;
            _logger.BackupHandler += () => _backUpService.MakeBackUp(_logger.File);
        }

        public async Task Run()
        {
            var taskList = new List<Task>
            {
                Task.Run(async () =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        var lognumber = i;
                        await _logger.WriteLogAsync($"Log №{lognumber} from first For");
                    }
                }),

                Task.Run(async () =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        var lognumber = i;
                        await _logger.WriteLogAsync($"Log №{lognumber} from second For");
                    }
                })
            };

            await Task.WhenAll(taskList);
        }
    }
}
