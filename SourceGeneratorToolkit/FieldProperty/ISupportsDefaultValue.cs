using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsDefaultValue<T> where T : SourceContainer
    {
        public DefaultValueContainer DefaultValue{ get; }
    }
}
