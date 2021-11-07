using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payme.Core.Common.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException()
            : base()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CustomException(string name, object key) : base($"Requested \"{name}\" ({key}) resulted into error")
        {
        }

        public bool Status { get; set; } = false;
        
    }
}
