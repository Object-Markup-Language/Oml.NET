namespace Oml.NET.Base
{
    public interface IOmlPropertyStringValueFormattingInfo : IOmlPropertyValueFormattingInfo
    {
        public bool GetIsLiteral();
        public void SetIsLiteral(bool value);

        public bool IsLiteral { get => GetIsLiteral(); set => SetIsLiteral(value); }
    }
}
