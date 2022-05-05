using Oml.NET.Base;

namespace Oml.NET.IO.Parsers
{
    public class OmlCommentParser : IOmlObjectParser
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Comment;
        
        public IOmlObject Parse(IOmlDocumentFormattingSettings settings, string oml)
        {
            string text = oml.TrimStart("//".ToCharArray());
            text = text.Trim();

            return new OmlComment(text);
        }
    }
}
