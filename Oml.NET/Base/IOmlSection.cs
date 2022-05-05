namespace Oml.NET.Base
{
    /// <summary>
    /// Represents a comment in an OML file.
    /// </summary>
    public interface IOmlSection : IOmlObject
    {
        public string GetText();
        public void SetText(string text);

        public string Text { get => GetText(); set => SetText(value); }
    }
}
