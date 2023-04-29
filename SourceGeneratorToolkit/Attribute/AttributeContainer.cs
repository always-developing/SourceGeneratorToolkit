namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container represeting an attribute
    /// </summary>
    public class AttributeContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AttributeContainer);

        /// <summary>
        /// Add an attribute to the container
        /// </summary>
        /// <param name="attributeName">The attribute name</param>
        /// <returns>The attribute statement created</returns>
        public AttributeStatement AddAttribute(string attributeName)
        {
            var attribute = new AttributeStatement(attributeName);
            _sourceItems.Add(attribute);

            return attribute;
        }
    }
}
