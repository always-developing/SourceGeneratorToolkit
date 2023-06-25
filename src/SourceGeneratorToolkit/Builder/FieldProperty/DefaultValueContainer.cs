namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a field default value
    /// </summary>
    public class DefaultValueContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(DefaultValueContainer);

        private string _defaultValue = "";

        /// <summary>
        /// Sets the default value of the container
        /// </summary>
        /// <param name="defaultValue"></param>
        public void SetDefautlValue(string defaultValue)
        {
            _defaultValue = defaultValue;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            if(!string.IsNullOrWhiteSpace(_defaultValue))
            {
                _sourceItems.Add(new EqualsStatement());
                _sourceItems.Add(new Statement(_defaultValue));
            }

            return base.ToSource();
        }
    }
}
