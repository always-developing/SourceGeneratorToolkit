using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ParameterContainer : SourceContainer
    {
        internal override string Name => nameof(ParameterContainer);

        public override string ToSource()
        {
            var sb = new StringBuilder();

            for(int i = 0; i< SourceItems.Count; i++) 
            {
                sb.Append(SourceItems[i].ToSource());

                if(i != SourceItems.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}
