using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Ansely.Email
{
    /// <summary>
    /// Abstract class of the email template.
    /// </summary>
    public abstract class AbstractEmailTemplate
    {
        public abstract string? FromDisplayName { get; protected set; }

        public abstract string? Subject { get; protected set; }

        public abstract string? Body { get; protected set; }

        private MailMessage mailMessage = new MailMessage();

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
