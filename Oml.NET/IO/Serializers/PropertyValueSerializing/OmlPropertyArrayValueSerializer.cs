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
                : throw new OmlSerializationException("Attempted to serialize array with non-array formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-array value with array serializer: " + value.GetType().Name);

        private static string Internal_Serializer(IOmlPropertyArrayValueFormattingInfo arrayFormat, object value)
        {
            StringBuilder builder = new StringBuilder();
            string separator = arrayFormat.IsSameLine ? " " : Environment.NewLine;

            builder.Append('(');
            builder.Append(separator);

            foreach (IOmlPropertyValueFormattingInfo valueFormat in arrayFormat.ChildFormattingInfos)
                valueFormat.IsInArray = true;

            Array array = value as Array;
            for (int i = 0; i < array.Length; i++)
            {
                string serializedItem;
                object item = array.GetValue(i);
                
                serializedItem = arrayFormat.OtherPropertyValueSerializers.TryGetValue(item.GetType(), out IOmlPropertyValueSerializer serializer)
                    ? serializer.Serialize(arrayFormat.ChildFormattingInfos[i], item)
                    : arrayFormat.FallbackSerializer.Serialize(arrayFormat.ChildFormattingInfos[i], arrayFormat.ChildFormattingInfos);

                builder.Append($"{serializedItem},{separator}");
            }

            foreach (IOmlPropertyValueFormattingInfo valueFormat in arrayFormat.ChildFormattingInfos)
                valueFormat.IsInArray = false;

            builder.Append(')');

            return builder.ToString();
        }
    }
}
