using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : SourceContainer
    {
        internal override string Name => nameof(FileContainer);

        private UsingsContainer _usingsContainer;

        public FileContainer(string fileName)
        {
            SourceText = fileName;
        }

        public override string ToTree()
        {
            StringBuilder sb = IndentedStringBuilder();

            sb.AppendLine($"-{this.GetType().Name} ({SourceText})");
            foreach (var item in SourceItems)
            {
                sb.Append(item.ToSource());
            }
            return sb.ToString().TrimEnd();
        }

        public FileContainer WithUsing(string @using)
        {
            if(_usingsContainer == null)
            {
                _usingsContainer = new UsingsContainer();
                SourceItems.Insert(0, _usingsContainer);
            }

            _usingsContainer.SourceItems.Add(new UsingStatemment(@using));

            return this;
        }

        public FileContainer WithNamespace(string @namespace, Action<NamespaceContainer> nsBuilder)
        {
            var ns = new NamespaceContainer(@namespace);
            SourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }

        public FileContainer WithFilescopedNamespace(string @namespace, Action<FilescopedNamespaceContainer> nsBuilder)
        {
            var ns = new FilescopedNamespaceContainer(@namespace);
            SourceItems.Add(ns);

            nsBuilder.Invoke(ns);

            return this;
        }


    }
}
