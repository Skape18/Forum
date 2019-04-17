using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DAL.EntityFramework.Exceptions
{
    [Serializable]
    class IncludePropertyNullException : Exception
    {
        public IncludePropertyNullException()
        {
            
        }

        public IncludePropertyNullException(string message) : base(message)
        {
        }

        public IncludePropertyNullException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IncludePropertyNullException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
