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
    /// A common email message template
    /// </summary>
    public class EmailTemplate : AbstractEmailTemplate
    {
        /// <summary>
        /// Initializes a new instance of the Ansely.Email.EmailTemplate by using the specified 
        /// infomation.
        /// </summary>
        /// <param name="fromDisplayName">The name displayed by the sender of the message.</param>
        /// <param name="subject">Mail subject.</param>
        /// <param name="body">Mail content.</param>
        public EmailTemplate(string fromDisplayName, string subject, string body)
        {
            this.FromDisplayName = fromDisplayName;
            this.Subject = subject;
            this.Body = body;
        }

        /// <summary>
        /// Initializes a new instance of the Ansely.Email.EmailTemplate by using the specified 
        /// infomation.
        /// </summary>
        /// <param name="fromDisplayName">The name displayed by the sender of the message.</param>
        /// <param name="mailMessage">Represents an email message that can be sent using the 
        /// System.Net.Mail.SmtpClient class.
        /// </param>
        public EmailTemplate(string fromDisplayName, MailMessage mailMessage)
        {
            this.FromDisplayName = fromDisplayName;
            this.MailMessage = mailMessage;
        }

        /// <summary>
        /// The name displayed by the sender of the message.
        /// </summary>
        public override string? FromDisplayName { get; protected set; }

        /// <summary>
        /// Mail subject.
        /// </summary>
        public override string? Subject { get; protected set; }

        /// <summary>
        /// Mail content.
        /// </summary>
        public override string? Body { get; protected set; }
    }
}
