using System;
using System.IO;
using System.Threading.Tasks;

namespace Modul3HW6.Services.Abstracts
{
    public interface ILogger
    {
        event Action BackupHandler;
        public FileInfo File { get; }
        public Task WriteLogAsync(string message);
    }
}