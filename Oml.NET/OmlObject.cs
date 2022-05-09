using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlObject"/>
    public abstract class OmlObject : IOmlObject
    {
        private IOmlObjectFormattingInfo _formattingInfo;

        /// <summary>
        /// Creates a new <see cref="OmlObject"/> with the given <see cref="IOmlObjectFormattingInfo"/>, or <see cref="EmptyOmlObjectFormattingInfo"/> if none is specified.
        /// </summary>
        /// <param name="formattingInfo">The object's <see cref="IOmlObjectFormattingInfo"/>.</param>
        public OmlObject(IOmlObjectFormattingInfo formattingInfo = null)
        {
            _formattingInfo = formattingInfo ?? new EmptyOmlObjectFormattingInfo();
        }

        /// <inheritdoc/>
        public abstract OmlObjectType OmlType { get; }
        
        /// <inheritdoc/>
        public IOmlObjectFormattingInfo GetFormattingInfo() => _formattingInfo;
        /// <inheritdoc/>
        public void SetFormattingInfo(IOmlObjectFormattingInfo formattingInfo) => _formattingInfo = formattingInfo;
    }
}
