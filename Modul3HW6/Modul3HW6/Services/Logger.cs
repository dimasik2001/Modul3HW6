using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modul3HW6.Configs;
using Modul3HW6.Services.Abstracts;

namespace Modul3HW6.Services
{
    public class Logger : ILogger
    {
        private readonly LoggerConfig _config;
        private readonly IFileService _fileService;
        private readonly StreamWriter _streamWriter;
        private readonly SemaphoreSlim _semaphoreSlim;
        private int _logsCounter;

        public Logger(IConfigService configService, IFileService fileService)
        {
            _config = configService.LoggerConfig;
            _fileService = fileService;
            Directory.CreateDirectory(_config.Path);
            File = new FileInfo($"{_config.Path}/{DateTime.UtcNow.ToString(_config.FileNameFormat)}{_config.FileExtension}");
            _streamWriter = new StreamWriter(File.FullName);
            _semaphoreSlim = new SemaphoreSlim(1);
            _logsCounter = 0;
        }

        public event Action BackupHandler;
        public FileInfo File { get; private set; }

        public async Task WriteLogAsync(string message)
        {
            await _semaphoreSlim.WaitAsync();
            await _fileService.WriteToFileAsync(_streamWriter, $"{DateTime.UtcNow.ToString(_config.LogFormat)}  {message}");
            _logsCounter++;
            if (_logsCounter >= _config.BackupInterval)
            {
                _logsCounter = 0;
                BackupHandler.Invoke();
            }

            _semaphoreSlim.Release();
        }
    }
}
