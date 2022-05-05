using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers.PropertyValueSerializing
{
    /// <summary>
    /// <see cref="IOmlPropertyValueSerializer"/> for serializing <see cref="string"/> values.
    /// </summary>
    public class OmlPropertyStringValueSerializer : IOmlPropertyValueSerializer
    {
        /// <inhericdoc/>
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value) => value is string text
            ? formattingInfo is IOmlPropertyStringValueFormattingInfo stringFormat
                ? $"{(stringFormat.IsLiteral ? "\"" : "")}{text}{(stringFormat.IsLiteral ? "\"" : "")}"
                : throw new OmlSerializationException("Attempted to serializer string with non-string formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-string value with string serializer: " + value.GetType().Name);
    }
}
