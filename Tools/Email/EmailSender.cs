using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// The implementation class of the Ansely.Email.IEmailSender interface.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderOptions config;

        public EmailSender(EmailSenderOptions emailSenderConfig) 
        {
            this.config = emailSenderConfig;
        }

        public async Task<EmailSenderResult> SendAsync<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new()
        {
            var template = new Template();

            return await SendAsync(template, addressees);
        }

        public async Task<EmailSenderResult> SendAsync(AbstractEmailTemplate template, List<string> addressees)
        {
            if(config.Secret == null)
            {
                throw new ArgumentNullException(nameof(config.Secret));
            }

            if (config.Host == null)
            {
                throw new ArgumentNullException(nameof(config.Host));
            }

            var mailMessage = template.MailMessage;

            mailMessage.From = new MailAddress(config.FromAddr, template.FromDisplayName);

            foreach (var addr in addressees)
            {
                mailMessage.To.Add(addr);
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = config.Host;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(config.FromAddr, config.Secret);

            try
            {
                await smtp.SendMailAsync(mailMessage);
                return EmailSenderResult.Success;
            }
            catch (Exception e)
            {
                var error = new EmailSenderError();
                error.Code = "0001";
                error.Description = e.Message;
                return EmailSenderResult.Failed(error);
            }
        }

        public EmailSenderResult Send<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new()
        {
            var template = new Template();

            return Send(template, addressees);
        }

        public EmailSenderResult Send(AbstractEmailTemplate template, List<string> addressees)
        {
            if (config.Secret == null)
            {
                throw new ArgumentNullException(nameof(config.Secret));
            }

            if (config.Host == null)
            {
                throw new ArgumentNullException(nameof(config.Host));
            }

            var mailMessage = template.MailMessage;

            mailMessage.From = new MailAddress(config.FromAddr, template.FromDisplayName);

            foreach (var addr in addressees)
            {
                mailMessage.To.Add(addr);
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = config.Host;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(config.FromAddr, config.Secret);

            try
            {
                smtp.Send(mailMessage);
                return EmailSenderResult.Success;
            }
            catch (Exception e)
            {
                var error = new EmailSenderError();
                error.Code = "0001";
                error.Description = e.Message;
                return EmailSenderResult.Failed(error);
            }
        }
    }
}
