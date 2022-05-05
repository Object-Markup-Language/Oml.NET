using Oml.NET.Base;

namespace Oml.NET
{
    /// <inheritdoc cref="IOmlDocumentBuilder"/>
    public class OmlDocumentBuilder : IOmlDocumentBuilder
    {
        private IOmlHeader _header;
        private readonly IOmlObjectList _steps;

        public OmlDocumentBuilder()
        {
            _steps = new OmlObjectList();
        }

        /// <inheritdoc/>
        public IOmlDocumentBuilder SetHeader(IOmlHeader header)
        {
            _header = header;
            return this;
        }

        /// <inheritdoc/>
        public IOmlDocumentBuilder AddProperty(string key, object value)
        {
            _steps.Add(new OmlProperty(key, value));
            return this;
        }

        /// <inheritdoc/>
        public IOmlDocumentBuilder AddSection(string text)
        {
            _steps.Add(new OmlSection(text));
            return this;
        }

        /// <inheritdoc/>
        public IOmlDocumentBuilder AddComment(string text)
        {
            _steps.Add(new OmlComment(text));
            return this;
        }

        /// <inheritdoc/>
        public IOmlDocument Build()
        {
            IOmlDocument document = new OmlDocument();
            document.SetHeader(_header);
            
            foreach (IOmlObject step in _steps)
                document.Add(step);

            return document;
        }
    }
}
