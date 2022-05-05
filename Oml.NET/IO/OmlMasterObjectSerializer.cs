using System;
using System.Collections.Generic;
using Oml.NET.Base;
using Oml.NET.IO.Serializers;

namespace Oml.NET.IO
{
    /// <summary>
    /// A wrapper over <see cref="IOmlObjectSerializer"/>s
    /// </summary>
    public static class OmlMasterObjectSerializer
    {
        private static readonly Dictionary<OmlObjectType, IOmlObjectSerializer> _serializers;

        static OmlMasterObjectSerializer()
        {
            _serializers = new Dictionary<OmlObjectType, IOmlObjectSerializer>() {
                { OmlObjectType.Header, new OmlHeaderSerializer() },
                { OmlObjectType.Property, new OmlPropertySerializer() },
                { OmlObjectType.Section, new OmlSectionSerializer() },
                { OmlObjectType.Comment, new OmlCommentSerializer() }
            };
        }

        public static string Serialize(OmlObjectType type, IOmlDocumentFormattingSettings settings, IOmlObject obj) => !_serializers.TryGetValue(type, out IOmlObjectSerializer serializer)
                ? throw new InvalidOperationException($"No serializer for type {type}. This should never happen.")
                : serializer.Serialize(settings, obj);
    }
}
