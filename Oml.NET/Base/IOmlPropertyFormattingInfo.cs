namespace Oml.NET.Base
{
    /// <summary>
    /// <see cref="IOmlObjectFormattingInfo"/> specific to <see cref="IOmlProperty"/>s.
    /// </summary>
    public interface IOmlPropertyFormattingInfo : IOmlObjectFormattingInfo
    {
        public IOmlPropertyValueFormattingInfo GetValueFormattingInfo();
        public void SetValueFormattingInfo(IOmlPropertyValueFormattingInfo formattingInfo);

        public IOmlPropertyValueFormattingInfo ValueFormattingInfo { get => GetValueFormattingInfo(); set => SetValueFormattingInfo(value); }
    }
}
