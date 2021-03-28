using System;
using System.Runtime.Serialization;

namespace ApplicationCore.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(int authorId) : base($"No author found with id {authorId}")
        { }

        protected AuthorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public AuthorNotFoundException(string message) : base(message)
        { }

        public AuthorNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}