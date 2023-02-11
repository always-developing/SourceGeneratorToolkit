using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class SourceStatement
    {
        public virtual string Name { get; }

        public virtual int Order { get; set; }

        public string SourceText { get; set; }

        public virtual string GenerateSource()
        {
            return SourceText;
        }
    }
}
