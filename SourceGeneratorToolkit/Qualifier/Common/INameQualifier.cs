using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Interface to mark the qualifier as support a name qualifier
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface INameQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
