using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// Provides some email server configurations of the email sender.
    /// </summary>
    public class EmailSenderOptions
    {
        /// <summary>
        /// Server host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Sender's email address.
        /// </summary>
        public string FromAddr { get; set; }

        /// <summary>
        /// Sender account secret.
        /// </summary>
        public string Secret { get; set; }

    }
}
