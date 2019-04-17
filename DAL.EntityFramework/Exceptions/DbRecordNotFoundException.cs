using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DAL.EntityFramework.Exceptions
{
    [Serializable]
    public class DbRecordNotFoundException : ArgumentException
    {
        public DbRecordNotFoundException()
        {
        }

        public DbRecordNotFoundException(string message, string paramName) : base(message, paramName)
        {
        }

        public DbRecordNotFoundException(string message, string paramName, Exception inner) : base(message, paramName, inner)
        {
        }

        protected DbRecordNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
