using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// Provides some email server configurations to the <see cref="IEmailSender"/>.
    /// <para>
    /// 提供给 <see cref="IEmailSender"/> 的一些邮件服务器配置选项。
    /// </para>
    /// </summary>
    public class EmailSenderOptions
    {
        /// <summary>
        /// Mail server host.
        /// <para>邮件服务器地址。</para>
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Sender's email address.
        /// <para>邮件发送者的邮箱地址。</para>
        /// </summary>
        public string? FromAddr { get; set; }

        /// <summary>
        /// Mail server access secret.
        /// <para>邮件服务器访问秘钥。</para>
        /// </summary>
        public string? Secret { get; set; }

    }
}
