using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Ansely.Email
{
    /// <summary>
    /// Abstract class of the email template.
    /// <para>邮件模板抽象类。</para>
    /// </summary>
    public abstract class AbstractEmailTemplate
    {
        /// <summary>
        /// The name displayed by the sender of the message.
        /// <para>消息发送方显示的名称。</para>
        /// </summary>
        public abstract string? FromDisplayName { get; protected set; }

        /// <summary>
        /// Mail subject.
        /// <para>邮件主题。</para>
        /// </summary>
        public abstract string? Subject { get; protected set; }

        /// <summary>
        /// Mail content.
        /// <para>邮件内容。</para>
        /// </summary>
        public abstract string? Body { get; protected set; }

        private MailMessage mailMessage = new MailMessage();

        /// <summary>
        /// Represents an email message that can be sent using the 
        /// <see cref="SmtpClient"/> class.
        /// <para>表示可以使用 <see cref="SmtpClient"/> 类发送的电子邮件消息。</para>
        /// </summary>
        public MailMessage MailMessage 
        { 
            get 
            {
                this.mailMessage.Body = Body;
                this.mailMessage.Subject = Subject;
                return this.mailMessage;
            } 
            set
            {
                this.Subject = value.Subject;
                this.Body= value.Body;
                this.mailMessage = value;
            }
        }

    }
}
