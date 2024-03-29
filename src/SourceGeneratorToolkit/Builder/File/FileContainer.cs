﻿using System;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a auto-geneated file 
    /// </summary>
    public class FileContainer : SourceContainer, ISupportsStatement<FileContainer>, ISupportsClasses<FileContainer>,
        ISupportsRecords<FileContainer>, ISupportsStructs<FileContainer>, ISupportsNamespaces<FileContainer>,
        ISupportsEnums<FileContainer>, ISupportsInterfaces<FileContainer>
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
        /// <param name="configuration">The build configuration to be used for the build</param>
        public FileContainer(string fileName, BuilderConfiguration configuration)
        {
            SourceText = fileName;
            Configuration = configuration;
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
        /// <param name="using">The namespace to include in the "using" statement</param>
        /// <param name="builder">The builder used to modify the properties of the "using" statement</param>
        /// <returns>The file container</returns>
        public FileContainer WithUsing(string @using, Action<UsingContainer> builder = null)
        {

            UsingList.AddUsing(@using, builder);
            return this;
        }

        /// <summary>
        /// Adds an extern alias to the file
        /// </summary>
        /// <param name="externAlias">The name of the extern alias</param>
        /// <returns>The file container</returns>
        public FileContainer WithExternAlias(string externAlias)
        {
            ExternAlias.AddExternAlias(externAlias);
            return this;
        }
    }
}
