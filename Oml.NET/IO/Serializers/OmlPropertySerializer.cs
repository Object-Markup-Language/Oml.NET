using System;
using System.Collections.Generic;
using System.Text;
using Oml.NET.Base;
using Oml.NET.Exceptions;
using Oml.NET.IO.Serializers.PropertyValueSerializing;

namespace Oml.NET.IO.Serializers
{
    /// <summary>
    /// <see cref="IOmlObjectSerializer"/> for serializing <see cref="IOmlProperty"/>s.
    /// </summary>
    public class OmlPropertySerializer : IOmlObjectSerializer
    {
        /// <inheritdoc/>
        public OmlObjectType HandledObjectType() => OmlObjectType.Property;

        private readonly Dictionary<Type, IOmlPropertyValueSerializer> _valueSerializers;
        private readonly IOmlPropertyValueSerializer _arraySerializer;
        private readonly IOmlPropertyValueSerializer _tableSerializer;
        private readonly IOmlPropertyValueSerializer _fallbackSerializer;

        public OmlPropertySerializer()
        {
            _valueSerializers = new Dictionary<Type, IOmlPropertyValueSerializer>() {
                { typeof(bool), new OmlPropertyBooleanValueSerializer() },
                { typeof(int), new OmlPropertyIntegerValueSerializer() },
                { typeof(string), new OmlPropertyStringValueSerializer() }
            };

            _arraySerializer = new OmlPropertyArrayValueSerializer();
            _tableSerializer = new OmlPropertyTableValueSerializer();
            //_fallbackSerializer = new OmlPropertyFallbackValueSerializer();
        }

        /// <inheritdoc/>
        public string Serialize(IOmlDocumentFormattingSettings settings, IOmlObject obj)
        {
            IOmlProperty property = (obj is IOmlProperty prop) ? prop : throw new OmlSerializationException("Attempted to serialize a non-property object as a property.");
            IOmlPropertyFormattingInfo formattingInfo = (obj.FormattingInfo is IOmlPropertyFormattingInfo info) ? info : throw new OmlSerializationException("Attempted to serialize a OML property with non-property formatting settings.");

            return new StringBuilder().Append(property.Key)
                .Append(' ')
                .Append('=')
                .Append(' ')
                .Append(SerializeValue(formattingInfo, property))
                .ToString();
        }

        private string SerializeValue(IOmlPropertyFormattingInfo formattingInfo, IOmlProperty property)
        {
            if (_valueSerializers.TryGetValue(property.Value.GetType(), out IOmlPropertyValueSerializer serializer))
                return serializer.Serialize(formattingInfo.ValueFormattingInfo, property.Value);

            if (property.Value.GetType().IsArray || property.Value is Array)
                return _arraySerializer.Serialize(formattingInfo.ValueFormattingInfo, property.Value);

            if (property.Value.GetType().IsSubclassOf(typeof(IOmlTable)))
                return _tableSerializer.Serialize(formattingInfo.ValueFormattingInfo, property.Value);

            return _fallbackSerializer.Serialize(formattingInfo.ValueFormattingInfo, property.Value);
        }
    }
}
