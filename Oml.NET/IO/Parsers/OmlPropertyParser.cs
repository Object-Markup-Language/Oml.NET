using System;

using Oml.NET.Base;
namespace Oml.NET.IO.Parsers
{
    public class OmlPropertyParser : IOmlObjectParser
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Property;
        
        public IOmlObject Parse(IOmlDocumentFormattingSettings settings, string oml) => throw new NotImplementedException();
    }
}
