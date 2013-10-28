using log4net;
using log4net.Config;
using MiaoBlog.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog log;


        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }


        public void Log(string message)
        {
            log.Info(message);
        }
    }
}
