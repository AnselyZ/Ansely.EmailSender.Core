namespace Ansely.Email
{
    /// <summary>
    /// Provides the interface for sending email.
    /// <para>提供邮件发送的接口。</para>
    /// </summary>
    public interface IEmailSender
    {
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
        public EmailSenderResult Send(AbstractEmailTemplate template, List<string> addressees);

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
        public EmailSenderResult Send<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new();

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
        public Task<EmailSenderResult> SendAsync(AbstractEmailTemplate template, List<string> addressees);

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
        public Task<EmailSenderResult> SendAsync<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new();

        
    }
}
