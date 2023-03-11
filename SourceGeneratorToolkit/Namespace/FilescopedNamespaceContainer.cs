using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class FilescopedNamespaceContainer : NamespaceContainer
    {
        internal override string Name => nameof(FilescopedNamespaceContainer);

        public FilescopedNamespaceContainer(string @namespace) : base(@namespace)
        {
        }

        public override string ToSource()
        {
            _sourceItems.Insert(0, new NewLineStatement($"namespace {SourceText};"));

            if (_accessModifier != null)
            {
                _sourceItems.Insert(0, _accessModifier);
            }

            return base.ToSource();
        }
    }
}
