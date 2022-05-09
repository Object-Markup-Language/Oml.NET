using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlComment"/>
    public class OmlComment : OmlObject, IOmlComment
    {
        private string _text;

        public OmlComment(string text = "")
        {
            _text = text;
        }

        /// <inheritdoc/>
        public override OmlObjectType OmlType => OmlObjectType.Comment;

        public string GetText() => _text;
        public void SetText(string text) => _text = text;
    }
}
