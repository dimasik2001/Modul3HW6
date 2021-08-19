using Modul3HW6.Configs;

namespace Modul3HW6.Services.Abstracts
{
    public interface IConfigService
    {
        BackUpConfig BackUpConfig { get; }
        LoggerConfig LoggerConfig { get; }
    }
}