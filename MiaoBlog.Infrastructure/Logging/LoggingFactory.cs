using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Logging
{
    public class LoggingFactory
    {
        private static ILogger logger;


        public static void InitializeLogFactory(ILogger logger)
        {
            LoggingFactory.logger = logger;
        }

        public static ILogger GetLogger()
        {
            return logger;
        }
    }
}
