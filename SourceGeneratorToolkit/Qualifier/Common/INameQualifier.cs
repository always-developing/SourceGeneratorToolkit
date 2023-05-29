using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface INameQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
