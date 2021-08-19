using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modul3HW6.Configs;
using Modul3HW6.Services.Abstracts;

namespace Modul3HW6.Services
{
    public class BackUpService : IBackUpService
    {
        private readonly BackUpConfig _config;
        private DirectoryInfo _directory;
        private int _filescounter;
        public BackUpService(IConfigService configService)
        {
            _config = configService.BackUpConfig;
            _filescounter = 0;
            _directory = new DirectoryInfo(_config.Path);
            DirectoryClear();
        }

        public void MakeBackUp(FileInfo fileInfo)
        {
            fileInfo.CopyTo($"{_directory.FullName}/{DateTime.UtcNow.ToString(_config.NameFormat)}[{_filescounter}]{_config.FileExtension}");
            _filescounter++;
        }

        private void DirectoryClear()
        {
            foreach (var file in _directory.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
