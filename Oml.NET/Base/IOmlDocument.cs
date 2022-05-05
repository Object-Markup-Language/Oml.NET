namespace Oml.NET.Base
{
    /// <summary>
    /// Represents a parsed OML document.
    /// </summary>
    public interface IOmlDocument : IOmlObjectList
    {
        public IOmlHeader GetHeader();
        public void SetHeader(IOmlHeader header);

        public IOmlDocumentFormattingSettings GetFormattingSettings();
        public void SetFormattingSettings(IOmlDocumentFormattingSettings settings);

        public IOmlHeader Header { get => GetHeader(); set => SetHeader(value); }
        public IOmlDocumentFormattingSettings FormattingSettings { get => GetFormattingSettings(); set => SetFormattingSettings(value); }
    }
}
