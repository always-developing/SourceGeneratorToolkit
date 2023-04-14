using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public enum GenericConstraint
    {
        Struct,
        Class,
        NullableClass,
        NotNull,
        Default,
        Unmanaged,
        New
    }
}
