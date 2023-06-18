using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a traditional namespace (one enclose by braces, vs a file scoped namespace)
    /// </summary>
    public class TraditionalNamespaceContainer : NamespaceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(TraditionalNamespaceContainer);

        /// <summary>
        /// Creates a traditional namespace
        /// </summary>
        /// <param name="namespace">The name of the namespace</param>
        /// <param name="configuration">The build configuration</param>
        public TraditionalNamespaceContainer(string @namespace, BuilderConfiguration configuration) : base(@namespace, configuration)
        {
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            var builderList = new List<SourceStatement>
            {
                new NewLineStatement($"namespace {SourceText}"),
                new BraceStartStatement()
            };

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}
