using Oml.NET.Base;
using Oml.NET.Utils;

namespace Oml.NET.IO.Parsers
{
    public class OmlSectionParser : IOmlObjectParser
    {
        public OmlObjectType HandledObjectType() => OmlObjectType.Section;
        
        public IOmlObject Parse(IOmlDocumentFormattingSettings settings, string oml)
        {
            OmlVerifier.VerifySectionStructure(oml);
            OmlVerifier.VerifySectionText(oml);
            oml = OmlVerifier.RemoveSectionBrackets(oml);
            
            return new OmlSection(oml);
        }
    }
}
