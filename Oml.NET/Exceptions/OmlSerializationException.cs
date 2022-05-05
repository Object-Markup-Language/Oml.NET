using System;

namespace Oml.NET.Exceptions
{
    [Serializable]
    public class OmlSerializationException : Exception
    {
        public OmlSerializationException() { }
        public OmlSerializationException(string message) : base(message) { }
        public OmlSerializationException(string message, Exception inner) : base(message, inner) { }
        protected OmlSerializationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
