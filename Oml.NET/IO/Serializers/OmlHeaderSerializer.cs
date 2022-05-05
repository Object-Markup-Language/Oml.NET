using System;
using Oml.NET.Base;

namespace Oml.NET.IO.Serializers
{
    public class OmlHeaderSerializer : IOmlObjectSerializer
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Header;

        // TODO write this once I write inline table serialization
        public string Serialize(IOmlDocumentFormattingSettings settings, IOmlObject obj) => throw new NotImplementedException();
    }
}
