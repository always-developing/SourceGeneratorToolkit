using System;
using System.Collections.Generic;
using System.Linq;
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
            SourceItems.Add(new CommaStatement());
        }

        public void AddConstraint(string value)
        {
            SourceItems.Add(new GenericConstraintStatement(value));
            SourceItems.Add(new CommaStatement());
        }

        public override string ToSource()
        {
            if(SourceItems.Last().GetType() == typeof(CommaStatement)) 
            {
                SourceItems.Remove(SourceItems.Last());
            }

            return base.ToSource();
        }
    }
}
