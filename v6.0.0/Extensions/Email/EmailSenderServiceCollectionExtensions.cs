using Ansely.Email;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up Email Sender related services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    /// </summary>
    public static class EmailSenderServiceCollectionExtensions
    {
        /// <summary>
        /// Add an EmailSender service to the service collection.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddEmailSender(this IServiceCollection serviceCollection, 
            Action<EmailSenderOptions> configure)
        {
            var config = new EmailSenderOptions();
            configure(config);

            serviceCollection.AddScoped<IEmailSender, EmailSender>(p =>
            {
                return new EmailSender(config);
            });

            return serviceCollection;
        }
    }
}
