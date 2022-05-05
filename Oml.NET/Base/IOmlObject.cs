namespace Oml.NET.Base
{
    /// <summary>
    /// A OML object is the catch-all term for every piece of an OML file, whether that's a header, a comment, an object, or a section.
    /// </summary>
    public interface IOmlObject
    {
        public IOmlObjectFormattingInfo GetFormattingInfo();
        public void SetFormattingInfo(IOmlObjectFormattingInfo formattingInfo);

        public IOmlObjectFormattingInfo FormattingInfo { get => GetFormattingInfo(); set => SetFormattingInfo(value); }
    }
}
