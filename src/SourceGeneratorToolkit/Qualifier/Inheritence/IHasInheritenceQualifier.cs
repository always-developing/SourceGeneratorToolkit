using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have inheritence related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IHasInheritenceQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
