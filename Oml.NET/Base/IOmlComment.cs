namespace Oml.NET.Base
{
    /// <summary>
    /// Represents a comment in an OML file; a line of text that doesn't add any data but clarifies the file's content to readers.
    /// </summary>
    public interface IOmlComment : IOmlObject
    {
        public string GetText();
        public void SetText(string value);

        public string Text { get => GetText(); set => SetText(value); }
    }
}
