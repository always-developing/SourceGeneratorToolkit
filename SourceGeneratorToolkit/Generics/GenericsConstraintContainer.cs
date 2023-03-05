using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal class GenericsConstraintContainer : SourceContainer
    {
        internal override string Name => nameof(GenericsConstraintContainer);

        public void AddConstraint(string genericKey, string value)
        {
            var match = SourceItems.FirstOrDefault(g => g.SourceText == genericKey);

            if(match != null && match is GenericConstraintContainer container) 
            {
                container.AddConstraint(value);

                return;
            }

            SourceItems.Add(new GenericConstraintContainer(genericKey, value));
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
