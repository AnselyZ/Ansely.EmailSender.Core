using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// EmailSender error message class containing status codes and error messages.
    /// </summary>
    public class EmailSenderError
    {
        /// <summary>
        /// Http response status code.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Error description.
        /// </summary>
        public string? Description { get; set; }
    }
}
