using System;
using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers.PropertyValueSerializing
{
    /// <summary>
    /// <see cref="IOmlPropertyValueSerializer"/> for serializing <see cref="int"/> values.
    /// </summary>
    public class OmlPropertyIntegerValueSerializer : IOmlPropertyValueSerializer
    {
        /// <inheritdoc/>
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value) => value is int num
            ? formattingInfo is IOmlPropertyIntegerValueFormattingInfo intFormat
                ? Convert.ToString(num, intFormat.Base)
                : throw new OmlSerializationException("Attempted to serialize integer with non-integer formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-integer value with integer serializer: " + value.GetType().Name);
    }
}
