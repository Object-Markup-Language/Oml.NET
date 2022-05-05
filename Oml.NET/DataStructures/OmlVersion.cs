using System;

namespace Oml.NET.DataStructures
{
    /// <summary>
    /// Represents an Oml release. See <a href = "https://github.com/Object-Markup-Language/Oml.Lang/blob/main/Versioning.md">here</a> for information on how Oml versions are formatted.
    /// </summary>
    public struct OmlVersion : IEquatable<OmlVersion>
    {
        /// <summary>
        /// The MAJOR version of this release.
        /// </summary>
        public int Major;

        /// <summary>
        /// The MINOR version of this release.
        /// </summary>
        public int Minor;

        /// <summary>
        /// The release candidate number. If this value is null, this version is not a release candidate.
        /// </summary>
        public int? ReleaseCandidateNumber;

        public OmlVersion(int major, int minor, int? releaseCandidateNumber = null)
        {
            Major = major;
            Minor = minor;
            ReleaseCandidateNumber = releaseCandidateNumber;
        }

        public override bool Equals(object obj) => (obj is OmlVersion version) && Equals(version);
        public bool Equals(OmlVersion other) => other.Major == Major && other.Minor == Minor && other.ReleaseCandidateNumber == ReleaseCandidateNumber;

        public override int GetHashCode() => Major ^ Minor ^ (ReleaseCandidateNumber ?? 1);

        public static bool operator ==(OmlVersion left, OmlVersion right) => left.Equals(right);
        public static bool operator !=(OmlVersion left, OmlVersion right) => !(left == right);
    }
}
