using System.Text;
using Oml.NET.Base;
using Oml.NET.Exceptions;
using Oml.NET.Utils;

namespace Oml.NET.IO.Serializers
{
    public class OmlCommentSerializer : IOmlObjectSerializer
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Comment;

        public string Serialize(IOmlDocumentFormattingSettings settings, IOmlObject obj) => new StringBuilder()
            .Append("//")
            .Append(" ".Multiply(settings.SpacesAfterCommentStart))
            .Append((obj is IOmlComment comment) ? comment.Text : throw new OmlSerializationException("Attempted to serialize a non-comment object as a comment."))
            .ToString();
    }
}
