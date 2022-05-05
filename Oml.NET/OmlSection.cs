using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlSection"/>
    public class OmlSection : OmlObject, IOmlSection
    {
        private string _text;

        public OmlSection(string text = null)
        {
            _text = text;
        }

        public string GetText() => _text;
        public void SetText(string text) => _text = text;

        /*public string Serialize(IOmlDocument document)
        {
            OmlVerifier.VerifySectionText(_text);

            return $"[{_text}]";
        }
        
        public void Parse(IOmlDocument document, string text)
        {
            text = text.Trim();

            OmlVerifier.VerifySectionStructure(text);
            OmlVerifier.VerifySectionText(text);

            _text = text;
        }*/
    }
}
