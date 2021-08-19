using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW6.Configs
{
    public class LoggerConfig
    {
        public string Path { get; set; }
        public string LogFormat { get; set; }
        public string FileNameFormat { get; set; }
        public string FileExtension { get; set; }
        public int BackupInterval { get; set; }
    }
}
