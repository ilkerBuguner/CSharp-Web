using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace PANDA
{
    class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }

}
