using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// The implementation class of the Ansely.Email.IEmailSender interface.
    /// <para>
    /// <see cref="IEmailSender"/> 接口的实现类。
    /// </para>
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderOptions config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ansely.Email.EmailSender"/> class with the EmailSenderOptions.
        /// <para>
        /// 传入 <see cref="EmailSenderOptions"/> 配置选项以实例化一个 <see cref="EmailSender"/> 实例。
        /// </para>
        /// </summary>
        /// <param name="emailSenderConfig">
        /// EmailSender configurations.
        /// <para>
        /// 有关于 <see cref="EmailSenderOptions"/> 的配置选项。
        /// </para>
        /// </param>
        public EmailSender(EmailSenderOptions emailSenderConfig) 
        {
            this.config = emailSenderConfig;
        }

        /// <summary>
        /// Send an email to the specified email address as an asynchronous opration.
        /// <para>
        /// 异步地发送一个邮件到指定的邮箱地址。
        /// </para>
        /// </summary>
        /// <typeparam name="Template">
        /// A type of the email message template.
        /// <para>
        /// 邮件消息模板泛型。
        /// </para>
        /// </typeparam>
        /// <param name="addressees">
        /// A list of specified addresses to receive mail.
        /// <para>
        /// 要接收的邮箱地址列表。
        /// </para>
        /// </param>
        /// <returns>
        /// The <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing
        /// the <see cref="Ansely.Email.EmailSenderResult"/> of sending the email.
        /// <para>
        /// 包含邮件发送结果 <see cref="Ansely.Email.EmailSenderResult"/> 的 
        /// <see cref="System.Threading.Tasks.Task"/> 对象。
        /// </para>
        /// </returns>
        public async Task<EmailSenderResult> SendAsync<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new()
        {
            var template = new Template();

            return await SendAsync(template, addressees);
        }

        /// <summary>
        /// Send an email to the specified email address as an asynchronous opration.
        /// <para>
        /// 异步地发送一个邮件到指定的邮箱地址。
        /// </para>
        /// </summary>
        /// <param name="template">
        /// A type of the email message template.
        /// <para>
        /// 邮件消息模板类实例。
        /// </para>
        /// </param>
        /// <param name="addressees">
        /// A list of specified addresses to receive mail.
        /// <para>
        /// 要接收的邮箱地址列表。
        /// </para>
        /// </param>
        /// <returns>
        /// The <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing
        /// the <see cref="Ansely.Email.EmailSenderResult"/> of sending the email.
        /// <para>
        /// 包含邮件发送结果 <see cref="Ansely.Email.EmailSenderResult"/> 的 
        /// <see cref="System.Threading.Tasks.Task"/> 对象。
        /// </para>
        /// </returns>
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

            if(config.FromAddr == null)
            {
                throw new ArgumentNullException(nameof(config.FromAddr));
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

        /// <summary>
        /// Send an email to the specified email address.
        /// <para>
        /// 发送一个邮件到指定的邮箱地址。
        /// </para>
        /// </summary>
        /// <typeparam name="Template">
        /// A type of the email message template.
        /// <para>
        /// 邮件消息模板泛型。
        /// </para>
        /// </typeparam>
        /// <param name="addressees">
        /// A list of specified addresses to receive mail.
        /// <para>
        /// 要接收的邮箱地址列表。
        /// </para>
        /// </param>
        /// <returns>
        /// The <see cref="Ansely.Email.EmailSenderResult"/> of sending the email.
        /// <para>
        /// 邮件发送结果。
        /// </para>
        /// </returns>
        public EmailSenderResult Send<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new()
        {
            var template = new Template();

            return Send(template, addressees);
        }

        /// <summary>
        /// Send an email to the specified email address.
        /// <para>
        /// 发送一个邮件到指定的邮箱地址。
        /// </para>
        /// </summary>
        /// <param name="template">
        /// A type of the email message template.
        /// <para>
        /// 邮件消息模板类实例。
        /// </para>
        /// </param>
        /// <param name="addressees">
        /// A list of specified addresses to receive mail.
        /// <para>
        /// 要接收的邮箱地址列表。
        /// </para>
        /// </param>
        /// <returns>
        /// The <see cref="Ansely.Email.EmailSenderResult"/> of sending the email.
        /// <para>
        /// 邮件发送结果。
        /// </para>
        /// </returns>
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

            if (config.FromAddr == null)
            {
                throw new ArgumentNullException(nameof(config.FromAddr));
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
