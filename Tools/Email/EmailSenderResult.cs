using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    public class EmailSenderResult
    {
        public bool Successed { get; protected set; }

        public static EmailSenderResult Success { 
            get 
            {
                return new EmailSenderResult
                {
                    Successed = true
                };
            } 
        }

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

        public IEnumerable<EmailSenderError> Errors
        {
            get
            {
                return errors;
            }
        }

    }
}
