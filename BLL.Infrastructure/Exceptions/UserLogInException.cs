using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BLL.Infrastructure.Exceptions
{
    [Serializable]
    public class UserLogInException : Exception
    {
        public UserLogInException()
        {
        }

        public UserLogInException(string message) : base(message)
        {
        }

        public UserLogInException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UserLogInException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
