﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FileContainer : SourceContainer
    {
        internal override string Name => nameof(FileContainer);

        private readonly UsingsContainer _usingsContainer = new UsingsContainer();

        public FileContainer(string fileName)
        {
            SourceText = fileName;
        }

        public override string ToSource()
        {
            _sourceItems.Insert(0, _usingsContainer);

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

        public FileContainer WithUsing(string @using)
        {
            _usingsContainer.AddUsing(@using);

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


    }
}
