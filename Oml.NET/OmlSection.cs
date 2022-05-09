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

        /// <inheritdoc/>
        public override OmlObjectType OmlType => OmlObjectType.Comment;

        public string GetText() => _text;
        public void SetText(string text) => _text = text;
    }
}
