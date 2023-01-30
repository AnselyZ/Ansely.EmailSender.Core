using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansely.Email
{
    /// <summary>
    /// Contains the EmailSender operation result information.
    /// <para>
    /// 包含 <see cref="IEmailSender"/> 的操作结果信息。
    /// </para>
    /// </summary>
    public class EmailSenderResult
    {
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// <para>表示操作是否成功的标志。</para>
        /// </summary>
        /// <value>
        /// True if the operation succeeded, otherwise false.
        /// <para>如果操作成功则为True，否则为false。</para>
        /// </value>
        public bool Successed { get; protected set; }

        /// <summary>
        /// Returns an <see cref="EmailSenderResult"/> indicating a successful operation.
        /// <para>
        /// 返回操作成功的 <see cref="EmailSenderResult"/> 实例。
        /// </para>
        /// </summary>
        /// <returns>
        /// An <see cref="EmailSenderResult"/> instance indicating a successful operation.
        /// <para>
        /// 表示操作成功的 <see cref="EmailSenderResult"/> 实例。
        /// </para>
        /// </returns>
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
        /// Creates an <see cref="EmailSenderResult"/> instance indicating a failed
        /// operation, with a list of errors if applicable.
        /// <para>
        /// 创建一个 <see cref="EmailSenderResult"/> 实例以指示一个失败的操作。如果适用，还会显示一个错误列表。
        /// </para>
        /// </summary>
        /// <param name="errors">An optional array of Ansely.Email.EmailSenderError 
        /// which caused the operation to fail.</param>
        /// <returns>
        /// An <see cref="EmailSenderResult"/> instance indicating a failed 
        /// operation, with a list of errors if applicable.
        /// <para>
        /// 一个指示失败操作的 <see cref="EmailSenderResult"/> 实例。如果适用，还会显示一个错误列表。
        /// </para>
        /// </returns>
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
        /// <para>
        /// 一个 <see cref="IEnumerable{T}"/> 类型的 <see cref="EmailSenderError"/> 实例，包含操作期间发生的错误。
        /// </para>
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
