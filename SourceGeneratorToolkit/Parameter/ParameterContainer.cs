using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ParameterContainer : SourceContainer
    {
        internal override string Name => nameof(ParameterContainer);

        public override string ToSource()
        {
            if (SourceItems.Any() && SourceItems.Last().GetType() == typeof(CommaStatement))
            {
                SourceItems.Remove(SourceItems.Last());
            }

            return base.ToSource();
        }

        public void AddParameter(string type, string name) 
        {
            SourceItems.Add(new ParameterStatement(type, name));
            SourceItems.Add(new CommaStatement());
        }
    }
}
