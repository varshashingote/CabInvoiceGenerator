using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator248
{
    public class CabInvoiceCustomException: Exception
    {
        /// <summary>
        /// Enum for defining different type of custom exception
        /// </summary>
        public ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME, NULL_RIDES, INVALID_USER_ID, INVALID_RIDETYPE
        }
    }
}

