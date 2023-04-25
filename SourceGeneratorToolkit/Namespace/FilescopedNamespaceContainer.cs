namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a filescoped namespace (one not enclose by braces, vs a traditional namespace)
    /// </summary>
    public class FilescopedNamespaceContainer : NamespaceContainer
    {

        /// <inheritdoc/>
        internal override string Name => nameof(FilescopedNamespaceContainer);

        /// <summary>
        /// Creates a filescoped namespace
        /// </summary>
        /// <param name="namespace">The name of the namespace</param>
        public FilescopedNamespaceContainer(string @namespace) : base(@namespace)
        {
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Insert(0, new NewLineStatement($"namespace {SourceText};"));

            return base.ToSource();
        }
    }
}
