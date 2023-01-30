using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// Contains the EmailSender result information.
    /// </summary>
    public class EmailSenderResult
    {
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Successed { get; protected set; }

        /// <summary>
        /// Returns an Ansely.Email.EmailSenderResult indicating a successful operation.
        /// </summary>
        /// <returns>An Ansely.Email.EmailSenderResult indicating a successful operation.</returns>
        public static EmailSenderResult Success { 
            get 
            {
                return new EmailSenderResult
                {
                    Successed = true
                };
            } 
        }

        /// <summary>
        /// Creates an Ansely.Email.EmailSenderResult indicating a failed
        /// operation, with a list of errors if applicable.
        /// </summary>
        /// <param name="errors">An optional array of Ansely.Email.EmailSenderError 
        /// which caused the operation to fail.</param>
        /// <returns>An Ansely.Email.EmailSenderResult indicating a failed 
        /// operation, with a list of errors if applicable.</returns>
        public static EmailSenderResult Failed(params EmailSenderError[] errors)
        {
            var res = new EmailSenderResult();
            foreach (var error in errors)
            {
                res.errors = res.errors.Append(error);
            }

            return res;
        }

        private IEnumerable<EmailSenderError> errors = new List<EmailSenderError>();

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of Ansely.Email.EmailSenderError
        /// instances containing errors that occurred during the operation.
        /// </summary>
        public IEnumerable<EmailSenderError> Errors
        {
            get
            {
                return errors;
            }
        }

    }
}
