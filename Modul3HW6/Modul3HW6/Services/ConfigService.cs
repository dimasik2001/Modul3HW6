using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW6.Configs;
using Newtonsoft.Json;
using Modul3HW6.Services.Abstracts;

namespace Modul3HW6.Services
{
    public class ConfigService : IConfigService
    {
        private const string _path = "config.json";
        private Config _config;

        public ConfigService()
        {
            Init();
        }

        public BackUpConfig BackUpConfig => _config.BackUpConfig;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;

        private void Init()
        {
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(_path));
        }
    }
}
