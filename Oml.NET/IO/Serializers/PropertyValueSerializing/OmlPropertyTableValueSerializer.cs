using System;
using System.Linq;
using System.Text;
using Oml.NET.Base;
using Oml.NET.Exceptions;

namespace Oml.NET.IO.Serializers.PropertyValueSerializing
{
    /// <summary>
    /// <see cref="IOmlPropertyValueSerializer"/> serializer for serializing <see cref="IOmlObject"/> values.
    /// </summary>
    public class OmlPropertyTableValueSerializer : IOmlPropertyValueSerializer
    {
        /// <inheritdoc/>
        public string Serialize(IOmlPropertyValueFormattingInfo formattingInfo, object value) => value is IOmlObject table
            ? formattingInfo is IOmlPropertyTableValueFormattingInfo tableFormat
                ? Internal_Serialize(tableFormat, table)
                : throw new OmlSerializationException("Attempted to serialize IOmlTable with non-IOmlTable formatting info: " + formattingInfo.GetType().Name)
            : throw new OmlSerializationException("Attempted to serialize non-IOmlTable value with IOmlTable serializer: " + value.GetType().Name);

        private static string Internal_Serialize(IOmlPropertyTableValueFormattingInfo tableFormat, IOmlObject table)
        {
            StringBuilder builder = new StringBuilder();
            string separator = tableFormat.IsSameLine ? " " : Environment.NewLine;

            builder.Append('{');
            builder.Append(separator);

            int count = table.Count();
            for (int i = 0; i < count; i++)
            {
                string serializedItem;
                object item = table.Get(i);

                serializedItem = tableFormat.OtherPropertyValueSerializers.TryGetValue(item.GetType(), out IOmlPropertyValueSerializer serializer)
                    ? serializer.Serialize(tableFormat.ChildFormattingInfos[i], item)
                    : tableFormat.FallbackSerializer.Serialize(tableFormat.ChildFormattingInfos[i], tableFormat.ChildFormattingInfos);

                builder.Append($"{serializedItem}{separator}");
            }

            builder.Append('}');

            return builder.ToString();
        }
    }
}
