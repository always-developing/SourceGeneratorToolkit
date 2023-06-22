using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have interface related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IImplementsQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
