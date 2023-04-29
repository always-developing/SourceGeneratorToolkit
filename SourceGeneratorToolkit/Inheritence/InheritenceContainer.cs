namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container which represents the inheritence of a container
    /// </summary>
    public class InheritenceContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(InheritenceContainer);

        /// <summary>
        /// Adds inheritence properties to the parent container
        /// </summary>
        /// <param name="baseCLassName">The name of the base class being inherited</param>
        /// <returns>The inheritence container</returns>
        public InheritenceContainer AddInheritence(string baseCLassName)
        {
            _sourceItems.Clear();

            _sourceItems.Add(new ColonStatement());
            _sourceItems.Add(new InheritenceStatement(baseCLassName));

            return this;
        }
    }
}
