using System;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Container representing a auto-geneated file 
    /// </summary>
    public class FileContainer : SourceContainer, ISupportsStatement<FileContainer>
    {
        /// <inheritdoc/>
        internal override string Name => nameof(FileContainer);

        /// <inheritdoc/>
        public UsingList UsingList { get; protected set; } = new UsingList();

        /// <inheritdoc/>
        public ExternAliasContainer ExternAlias { get; protected set; } = new ExternAliasContainer();

        /// <summary>
        /// Creates a source generated file instance with the given file name
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        public FileContainer(string fileName)
        {
            SourceText = fileName;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            _sourceItems.Insert(0, UsingList);
            _sourceItems.Insert(0, ExternAlias);

            return base.ToSource();
        }

        /// <inheritdoc/>
        public override string ToTree(int treeLevel)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{TreePrefix(treeLevel)}{this.GetType().Name} ({SourceText})");

            foreach (var item in SourceItems)
            {
                sb.Append(item.ToTree(treeLevel + 1));
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Adds a "using" statement to the file
        /// </summary>
        //// <param name="using">The namespace to include in the "using" statement</param>
        /// <param name="builder">The builder used to modify the properties of the "using" statement</param>
        /// <returns>The file container</returns>
        public FileContainer WithUsing(string @using, Action<UsingContainer> builder = null)
        {

            UsingList.AddUsing(@using, builder);
            return this;
        }

        public FileContainer WithNamespace(string @namespace, Action<NamespaceContainer> nsBuilder)
        {
            var ns = new TraditionalNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }

        public FileContainer WithFilescopedNamespace(string @namespace, Action<NamespaceContainer> nsBuilder)
        {
            var ns = new FilescopedNamespaceContainer(@namespace);
            _sourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }

        public FileContainer WithClass(string className, Action<ClassContainer> classBuilder)
        {
            var classContainer = new ClassContainer(className);

            _sourceItems.Add(classContainer);
            classBuilder.Invoke(classContainer);

            return this;
        }

        public FileContainer WithExternAlias(string externAlias)
        {
            ExternAlias.AddExternAlias(externAlias);
            return this;
        }


    }
}
