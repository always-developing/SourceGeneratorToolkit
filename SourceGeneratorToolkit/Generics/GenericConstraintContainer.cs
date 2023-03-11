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
            _sourceItems.Add(new GenericConstraintStatement(value));
            _sourceItems.Add(new CommaStatement());
        }

        public void AddConstraint(string value)
        {
            _sourceItems.Add(new GenericConstraintStatement(value));
            _sourceItems.Add(new CommaStatement());
        }

        public override string ToSource()
        {
            if(SourceItems.Last().GetType() == typeof(CommaStatement)) 
            {
                _sourceItems.Remove(SourceItems.Last());
            }

            _sourceItems.Insert(0, new Statement($" where {SourceText} :"));

            return base.ToSource();
        }
    }
}
