using System;
using System.Collections.Generic;
using Oml.NET.Base;
using Oml.NET.IO.Parsers;

namespace Oml.NET.IO
{
    /// <summary>
    /// A wrapper over <see cref="IOmlObjectParser"/>s
    /// </summary>
    public static class OmlMasterObjectParser
    {
        private static readonly Dictionary<OmlObjectType, IOmlObjectParser> _parsers;

        static OmlMasterObjectParser()
        {
            _parsers = new Dictionary<OmlObjectType, IOmlObjectParser>() {
                { OmlObjectType.Header, new OmlHeaderParser() },
                { OmlObjectType.Property, new OmlPropertyParser() },
                { OmlObjectType.Section, new OmlSectionParser() },
                { OmlObjectType.Comment, new OmlCommentParser() }
            };
        }

        public static IOmlObject Parse(IOmlDocumentFormattingSettings settings, OmlObjectType type, string oml) => !_parsers.TryGetValue(type, out IOmlObjectParser parser)
                ? throw new InvalidOperationException($"No parser for type {type}. This should never happen.")
                : parser.Parse(settings, oml);
    }
}
