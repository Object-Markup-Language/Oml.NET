using System;
using Oml.NET.Base;

namespace Oml.NET.IO.Parsers
{
    public class OmlHeaderParser : IOmlObjectParser
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Header;
        
        // TODO implement once inline tables are implemented
        public IOmlObject Parse(IOmlDocumentFormattingSettings settings, string oml) => throw new NotImplementedException();
    }
}
