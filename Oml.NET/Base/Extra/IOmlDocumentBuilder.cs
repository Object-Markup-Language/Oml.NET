namespace Oml.NET.Base
{
    /// <summary>
    /// Allows you to create a <see cref="IOmlDocument"/> using builder syntax.
    /// </summary>
    public interface IOmlDocumentBuilder
    {
        /// <summary>
        /// Sets the documents header to the provided header.
        /// </summary>
        /// <param name="header">The desired OML header.</param>
        public IOmlDocumentBuilder SetHeader(IOmlHeader header);

        /// <summary>
        /// Adds the specified <see cref="IOmlProperty"/> to this document;
        /// </summary>
        /// <param name="property">The property to add.</param>
        public IOmlDocumentBuilder AddProperty(string key, object value);

        /// <summary>
        /// All objects added will be under this section until the next <see cref="AddSection(string)"/> call.
        /// </summary>
        /// <param name="text">The section's name.</param>
        public IOmlDocumentBuilder AddSection(string text);

        /// <summary>
        /// Add a comment to this OML document using the current comment sequence.
        /// </summary>
        /// <param name="text">The text of the comment</param>
        public IOmlDocumentBuilder AddComment(string text);

        /// <summary>
        /// Builds the OML document.
        /// </summary>
        /// <returns>The built document.</returns>
        public IOmlDocument Build();
    }
}
