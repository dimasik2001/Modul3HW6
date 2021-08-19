using System.IO;
using System.Threading.Tasks;

namespace Modul3HW6.Services.Abstracts
{
    public interface IFileService
    {
        Task WriteToFileAsync(StreamWriter streamWriter, string text);
    }
}