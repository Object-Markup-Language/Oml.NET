namespace Oml.NET.Base
{
    public interface IOmlObjectParser
    {
        public OmlObjectType HandledObjectType();

        public IOmlObject Parse(IOmlDocumentFormattingSettings settings, string oml);
    }
}
