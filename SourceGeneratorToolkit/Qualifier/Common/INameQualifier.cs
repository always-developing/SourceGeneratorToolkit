using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Interface to mark the qualifier as support a name qualifier
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface INameQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
