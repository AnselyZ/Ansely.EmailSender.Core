using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Ansely.Email
{
    /// <summary>
    /// Abstract class of the email template.
    /// </summary>
    public abstract class AbstractEmailTemplate
    {
        /// <summary>
        /// The name displayed by the sender of the message.
        /// </summary>
        public abstract string? FromDisplayName { get; protected set; }

        /// <summary>
        /// Mail subject.
        /// </summary>
        public abstract string? Subject { get; protected set; }

        /// <summary>
        /// Mail content.
        /// </summary>
        public abstract string? Body { get; protected set; }

        private MailMessage mailMessage = new MailMessage();

        /// <summary>
        /// Mail message.
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
