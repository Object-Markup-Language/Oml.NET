using System;
using System.Text;
using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers.PropertyValueSerializing
{
    /// <summary>
    /// <see cref="IOmlPropertyValueSerializer"/> for serializing arrays.
    /// </summary>
    public class OmlPropertyArrayValueSerializer : IOmlPropertyValueSerializer
    {
        /// <inhericdoc/>
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value) => (value.GetType().IsArray || value is Array)
            ? formattingInfo is IOmlPropertyArrayValueFormattingInfo arrayFormat
                ? Internal_Serializer(arrayFormat, value)
                : throw new OmlSerializationException("Attempted to serializer integer with non-integer formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-array value with array serializer: " + value.GetType().Name);

        private string Internal_Serializer(IOmlPropertyArrayValueFormattingInfo arrayFormat, object value)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("( ");

            Array array = value as Array;
            for (int i = 0; i < array.Length; i++)
            {
                string serializedItem;
                object item = array.GetValue(i);

                if (arrayFormat.OtherPropertyValueSerializers.TryGetValue(item.GetType(), out IOmlPropertyValueSerializer serializer))
                    serializedItem = serializer.Serialize(arrayFormat.ChildFormattingInfos[i], item);
                
                serializedItem = arrayFormat.FallbackSerializer.Serialize(arrayFormat.ChildFormattingInfos[i], arrayFormat.ChildFormattingInfos);
            }

            builder.Append(" )");

            return builder.ToString()
        }
    }
}
