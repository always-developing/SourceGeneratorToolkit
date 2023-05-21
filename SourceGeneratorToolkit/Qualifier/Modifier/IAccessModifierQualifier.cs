using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface IAccessModifierQualifier<TQualifier> where TQualifier : QualfierBuilder
    {
    }
}
