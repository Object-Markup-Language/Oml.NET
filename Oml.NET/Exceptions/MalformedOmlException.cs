using System;
using System.Runtime.Serialization;

namespace Oml.NET.Exceptions
{
    /// <summary>
    /// Throws if you attempt to parse invalid or malformed OML.
    /// </summary>
    [Serializable]
    public class MalformedOmlException : Exception
    {
        public MalformedOmlException() { }
        public MalformedOmlException(string message) : base(message) { }
        public MalformedOmlException(string message, Exception inner) : base(message, inner) { }
        
        protected MalformedOmlException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
