using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// <see cref="IEmailSender"/> error message class containing status codes and error messages.
    /// <para>
    /// <see cref="IEmailSender"/> 异常消息类，包含状态码和异常消息。
    /// </para>
    /// </summary>
    public class EmailSenderError
    {
        /// <summary>
        /// Http response status code.
        /// <para>Http响应状态码。</para>
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Error description.
        /// <para>异常描述信息。</para>
        /// </summary>
        public string? Description { get; set; }
    }
}
