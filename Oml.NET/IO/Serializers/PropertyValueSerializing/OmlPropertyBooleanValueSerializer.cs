using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers.PropertyValueSerializing
{
    /// <summary>
    /// <see cref="IOmlPropertyValueSerializer"/> for serializing <see cref="bool"/> values.
    /// </summary>
    public class OmlPropertyBooleanValueSerializer : IOmlPropertyValueSerializer
    {
        /// <inheritdoc/>
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value) => value is bool flag
            ? formattingInfo is IOmlPropertyBooleanValueFormattingInfo boolFormat
                ? flag.ToString()
                : throw new OmlSerializationException("Attempted to serializer boolean with non-boolean formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-boolean value with boolean serializer: " + value.GetType().Name);
    }
}
