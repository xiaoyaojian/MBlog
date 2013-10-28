using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings applicationSettings;


        public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings)
        {
            ApplicationSettingsFactory.applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return applicationSettings;
        }
    }
}
