namespace Oml.NET.Base
{
    public interface IOmlObjectSerializer
    {
        public OmlObjectType HandledObjectType();

        public string Serialize(IOmlDocumentFormattingSettings settings, IOmlObject obj);
    }
}
