using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class TraditionalNamespaceContainer : NamespaceContainer
    {
        public TraditionalNamespaceContainer(string @namespace) : base(@namespace)
        {
        }

        public override string ToSource()
        {
            var builderList = new List<SourceStatement>();

            builderList.Add(new NewLineStatement($"namespace {SourceText}"));
            builderList.Add(new BraceStartStatement());

            _sourceItems.InsertRange(0, builderList);

            _sourceItems.Add(new BraceEndStatement());
            _sourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}
