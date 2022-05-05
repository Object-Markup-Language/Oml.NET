using System.Text;
using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers
{
    public class OmlSectionSerializer : IOmlObjectSerializer
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Section;

        public string Serialize(IOmlDocumentFormattingSettings settings, IOmlObject obj) => new StringBuilder()
            .Append('[')
            .Append((obj is IOmlSection section) ? section.Text : throw new OmlSerializationException("Attempted to serialize a non-section object as a section."))
            .Append(']')
            .ToString();
    }
}
