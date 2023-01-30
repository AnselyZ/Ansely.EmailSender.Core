namespace Ansely.Email
{
    /// <summary>
    /// Provides the interface for sending email.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Send an email to the specified email address.
        /// </summary>
        /// <param name="template">An email message template.</param>
        /// <param name="addressees">A list of specified addresses to receive mail.</param>
        /// <returns>The result of sending the email.</returns>
        public EmailSenderResult Send(AbstractEmailTemplate template, List<string> addressees);

        /// <summary>
        /// Send an email to the specified email address.
        /// </summary>
        /// <typeparam name="Template">A type of the email message template.</typeparam>
        /// <param name="addressees">A list of specified addresses to receive mail.</param>
        /// <returns>The result of sending the email.</returns>
        public EmailSenderResult Send<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new();

        /// <summary>
        /// Send an email to the specified email address as an asynchronous opration.
        /// </summary>
        /// <param name="template">An email message template.</param>
        /// <param name="addressees">A list of specified addresses to receive mail.</param>
        /// <returns>The result of sending the email.</returns>
        public Task<EmailSenderResult> SendAsync(AbstractEmailTemplate template, List<string> addressees);

        /// <summary>
        /// Send an email to the specified email address as an asynchronous opration.
        /// </summary>
        /// <typeparam name="Template">A type of the email message template.</typeparam>
        /// <param name="addressees">A list of specified addresses to receive mail.</param>
        /// <returns>The result of sending the email.</returns>
        public Task<EmailSenderResult> SendAsync<Template>(List<string> addressees) where Template : AbstractEmailTemplate, new();

        
    }
}
