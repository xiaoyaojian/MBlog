using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Email
{
    public class EmailServiceFactory
    {
        private static IEmailService emailService;


        public static void InitializeEmailServiceFactory(IEmailService emailService)
        {
            EmailServiceFactory.emailService = emailService;
        }

        public static IEmailService GetEmailService()
        {
            return emailService;
        }
    }
}
