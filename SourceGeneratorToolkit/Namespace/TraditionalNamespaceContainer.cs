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
            var tempList = new List<SourceStatement>();

            if (_accessModifier != null)
            {
                tempList.Add(_accessModifier);
            }

            tempList.Add(new NewLineStatement($"namespace {SourceText}"));
            tempList.Add(new BraceStartStatement());

            SourceItems.InsertRange(0, tempList);

            SourceItems.Add(new BraceEndStatement());
            SourceItems.Add(new NewLineStatement());

            return base.ToSource();
        }
    }
}
