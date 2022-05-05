namespace Oml.NET.Base
{
    public interface IOmlPropertyValueSerializer
    {
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value);
    }
}
