using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BLL.Infrastructure.Exceptions
{
    [Serializable]
    public class DbQueryResultNullException : ArgumentException
    {

        public DbQueryResultNullException()
        {
        }

        public DbQueryResultNullException(string message, string repositoryName) : base(message, repositoryName)
        {
        }

        public DbQueryResultNullException(string message, string repositoryName, Exception inner) : base(message, repositoryName, inner)
        {
        }

        protected DbQueryResultNullException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
