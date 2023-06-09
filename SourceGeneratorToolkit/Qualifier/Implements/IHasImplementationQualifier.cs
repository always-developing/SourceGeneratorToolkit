using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have interface related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IHasImplementationQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
