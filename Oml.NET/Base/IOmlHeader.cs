using Oml.NET.DataStructures;

namespace Oml.NET.Base
{
    /// <summary>
    /// Represents a header in an OML file; a line of text specifying how the document should be parsed.
    /// </summary>
    public interface IOmlHeader : IOmlTable, IOmlObject
    {
        public const string VersionKey = "Version";

        public OmlVersion Version { get => GetVersion(); set => SetVersion(value); }

        public OmlVersion GetVersion() => Get(VersionKey).GetValue<OmlVersion>();
        public void SetVersion(OmlVersion version) => Get(VersionKey).SetValue(version);
    }
}
