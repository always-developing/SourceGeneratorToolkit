using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit 
{
    internal class GenericConstraintContainer : SourceContainer
    {
        internal override string Name => nameof(GenericConstraintContainer);

        public GenericConstraintContainer(string genericKey, string value)
        {
            SourceText = genericKey;
            SourceItems.Add(new GenericConstraintStatement(value));
        }

        public void AddConstraint(string value)
        {
            SourceItems.Add(new GenericConstraintStatement(value));
        }

        public override string ToSource()
        {
            var sb = new StringBuilder();

            for(int i = 0; i < SourceItems.Count; i++)
            {
                sb.Append(SourceItems[i].ToSource());

                if (i != SourceItems.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}
