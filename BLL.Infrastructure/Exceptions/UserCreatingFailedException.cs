using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BLL.Infrastructure.Exceptions
{
    [Serializable]
    public class UserCreationException : Exception
    {
        public UserCreationException()
        {
        }

        public UserCreationException(string message) : base(message)
        {
        }

        public UserCreationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UserCreationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
