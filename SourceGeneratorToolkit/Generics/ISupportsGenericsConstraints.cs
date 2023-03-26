using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsGenericsConstraints<T> where T : SourceContainer
    {
        public GenericConstraintList ConstraintContainer { get; }
    }
}
