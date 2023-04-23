using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : SourceContainer, ISupportsStatement<FileContainer>
    {
        internal override string Name => nameof(FileContainer);

        public UsingList UsingList { get; protected set; } = new UsingList();

        public ExternAliasContainer ExternAlias { get; protected set; } = new ExternAliasContainer();

        public FileContainer(string fileName)
        {
            SourceText = fileName;
        }

        public override string ToSource()
        {
            _sourceItems.Insert(0, UsingList);
            _sourceItems.Insert(0, ExternAlias);

            return base.ToSource();
        }

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
