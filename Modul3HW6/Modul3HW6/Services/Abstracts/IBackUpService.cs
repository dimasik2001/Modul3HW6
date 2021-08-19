using System.IO;

namespace Modul3HW6.Services.Abstracts
{
    public interface IBackUpService
    {
        void MakeBackUp(FileInfo fileInfo);
    }
}