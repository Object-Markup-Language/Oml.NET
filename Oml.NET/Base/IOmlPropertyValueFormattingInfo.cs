namespace Oml.NET.Base
{
    /// <summary>
    /// Describes how a property's value should be formatted when serialized.
    /// </summary>
    public interface IOmlPropertyValueFormattingInfo
    {
        public bool GetIsInArray();
        public void SetIsInArray(bool value);

        public bool IsInArray { get => GetIsInArray(); set => SetIsInArray(value); }
    }
}
