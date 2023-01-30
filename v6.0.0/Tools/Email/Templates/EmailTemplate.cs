using Ansely.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// A common email message template.
    /// <para>通用邮件消息模板。</para>
    /// </summary>
    public class EmailTemplate : AbstractEmailTemplate
    {
        /// <summary>
        /// Initializes a new instance of the Ansely.Email.EmailTemplate by using the specified 
        /// infomation.
        /// <para>
        /// 使用指定的信息初始化 <see cref="EmailTemplate"/> 的一个新实例。
        /// </para>
        /// </summary>
        /// <param name="fromDisplayName">
        /// The name displayed by the sender of the message.
        /// <para>消息发送方显示的名称。</para>
        /// </param>
        /// <param name="subject">
        /// Mail subject.
        /// <para>邮件主题。</para>
        /// </param>
        /// <param name="body">
        /// Mail content.
        /// <para>邮件内容。</para>
        /// </param>
        public EmailTemplate(string fromDisplayName, string subject, string body)
        {
            this.FromDisplayName = fromDisplayName;
            this.Subject = subject;
            this.Body = body;
        }

        /// <summary>
        /// Initializes a new instance of the Ansely.Email.EmailTemplate by using the specified 
        /// infomation.
        /// <para>
        /// 使用指定的信息初始化 <see cref="EmailTemplate"/> 的一个新实例。
        /// </para>
        /// </summary>
        /// <param name="fromDisplayName">
        /// The name displayed by the sender of the message.
        /// <para>消息发送方显示的名称。</para>
        /// </param>
        /// <param name="mailMessage">
        /// Represents an email message that can be sent using the 
        /// <see cref="SmtpClient"/> class.
        /// <para>表示可以使用 <see cref="SmtpClient"/> 类发送的电子邮件消息。</para>
        /// </param>
        public EmailTemplate(string fromDisplayName, MailMessage mailMessage)
        {
            this.FromDisplayName = fromDisplayName;
            this.MailMessage = mailMessage;
        }

        /// <summary>
        /// The name displayed by the sender of the message.
        /// <para>消息发送方显示的名称。</para>
        /// </summary>
        public override string? FromDisplayName { get; protected set; }

        /// <summary>
        /// Mail subject.
        /// <para>邮件主题。</para>
        /// </summary>
        public override string? Subject { get; protected set; }

        /// <summary>
        /// Mail content.
        /// <para>邮件内容。</para>
        /// </summary>
        public override string? Body { get; protected set; }
    }
}
