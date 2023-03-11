using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class GenericConstraintList : SourceContainer
    {
        internal override string Name => nameof(GenericConstraintList);

        public void AddConstraint(string genericKey, string value)
        {
            var match = SourceItems.FirstOrDefault(g => g.SourceText == genericKey);

            if(match != null && match is GenericConstraintContainer container) 
            {
                container.AddConstraint(value);

                return;
            }

            _sourceItems.Add(new GenericConstraintContainer(genericKey, value));
        }

        public override string ToSource()
        {
            if(!SourceItems.Any())
            {
                return "";
            }

            return base.ToSource();
        }
    }
}
