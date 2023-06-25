namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing an enum member
    /// </summary>
    public class EnumMemberContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(EnumMemberContainer);

        /// <summary>
        /// Constructor for the EnumMemberContainer class
        /// </summary>
        /// <param name="name">The enum member name</param>
        public EnumMemberContainer(string name)
        {
            _sourceItems.Add(new Statement(name));
        }

        /// <summary>
        /// Constructor for the EnumMemberContainer class
        /// </summary>
        /// <param name="name">The enum member name</param>
        /// <param name="value">The enum member value</param>
        public EnumMemberContainer(string name, string value)
        {
            _sourceItems.Add(new Statement(name));
            _sourceItems.Add(new EqualsStatement());
            _sourceItems.Add(new Statement(value));
        }
    }
}
