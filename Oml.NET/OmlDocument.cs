using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlDocument"/>
    public class OmlDocument : OmlObjectList, IOmlDocument
    {
        private IOmlHeader _header;
        private IOmlDocumentFormattingSettings _serializationSettings;

        public OmlDocument(IOmlHeader header = null, IOmlDocumentFormattingSettings serializationSettings = null)
        {
            _header = header;
            _serializationSettings = serializationSettings;
        }

        public IOmlHeader GetHeader() => _header;
        public void SetHeader(IOmlHeader header) => _header = header;

        public IOmlDocumentFormattingSettings GetFormattingSettings() => _serializationSettings;
        public void SetFormattingSettings(IOmlDocumentFormattingSettings settings) => _serializationSettings = settings;
    }
}
