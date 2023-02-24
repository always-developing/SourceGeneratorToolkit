using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class GenericContainer : SourceContainer
    {
        internal override string Name => nameof(GenericContainer);

        internal GenericsConstraintContainer Constraints = new GenericsConstraintContainer();

        internal string _genericKey;

        public GenericContainer()
        {
        }

        public override string ToSource()
        {
            var sb = new IndentedStringBuilder(IndentLevel);

            if(!SourceItems.Any())
            {
                return "";
            }

            sb.Append(new ChevronStartStatement().ToSource());

            for(int i = 0; i < SourceItems.Count; i++)
            {
                sb.Append(SourceItems[i].ToSource());

                if(i != SourceItems.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append(new ChevronEndStatement().ToSource());
            return sb.ToString();
        }

        internal void AddGeneric(string value)
        {
            SourceItems.Add(new GenericStatement(value));
        }

        //public GenericContainer WithConstraint()


    }
}
