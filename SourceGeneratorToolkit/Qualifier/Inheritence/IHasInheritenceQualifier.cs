using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have inheritence related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IHasInheritenceQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
