using System;
using System.Threading.Tasks;
using Modul3HW6.Services;

namespace Modul3HW6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var appstarter = new AppStarter();
            var starter = appstarter.Starter;
            await starter.Run();
        }
    }
}
