using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence
{
    public static class Configuration
    {
        public static string GetConnectionString()
        {
            // API deki appsettings.json dosyasınında gerekli dataları çekmek için kullanılan kod parçacığı
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerce.API"));
            configurationManager.AddJsonFile("appsettings.json");
            var currentDb = configurationManager.GetConnectionString("CurrentDb");
            return configurationManager.GetConnectionString(currentDb);
        }
    }
}
