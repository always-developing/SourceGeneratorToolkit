using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsField<T> where T : SourceContainer
    {
        public FieldList Fields { get; }
    }
}
