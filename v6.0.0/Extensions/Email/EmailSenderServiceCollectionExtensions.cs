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
    /// Extension methods for setting up <see cref="IEmailSender"/> related services in an 
    /// <see cref="IServiceCollection"/>.
    /// <para>在 <see cref="IServiceCollection"/> 中设置 <see cref="IEmailSender"/> 相关服务的扩展方法。</para>
    /// </summary>
    public static class EmailSenderServiceCollectionExtensions
    {
        /// <summary>
        /// Add an EmailSender service to the service collection.
        /// <para>向服务集合中添加 <see cref="IEmailSender"/> 服务。</para>
        /// </summary>
        /// <param name="serviceCollection">
        /// Service collection.
        /// <para>依赖注入容器。</para>
        /// </param>
        /// <param name="configure">
        /// The configuration options delegate passed in with <see cref="EmailSenderOptions"/> as an argument.
        /// <para>以 <see cref="EmailSenderOptions"/> 为参数传入的配置选项委托。</para>
        /// </param>
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
