using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW6.Services.Abstracts;

namespace Modul3HW6.Services
{
    public class FileService : IFileService
    {
        public async Task WriteToFileAsync(StreamWriter streamWriter, string text)
        {
            await streamWriter.WriteLineAsync(text);
            await streamWriter.FlushAsync();
        }
    }
}
