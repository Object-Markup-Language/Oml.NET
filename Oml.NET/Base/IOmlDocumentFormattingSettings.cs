namespace Oml.NET.Base
{
    /// <summary>
    /// Represents settings which are used when formatting a <see cref="IOmlDocument"/> to a string.
    /// </summary>
    public interface IOmlDocumentFormattingSettings
    {
        public int GetSpacesAfterCommentStart();
        public void SetSpacesAfterCommentStart(int amount);

        public int SpacesAfterCommentStart { get => GetSpacesAfterCommentStart(); set => SetSpacesAfterCommentStart(value); }
    }
}
