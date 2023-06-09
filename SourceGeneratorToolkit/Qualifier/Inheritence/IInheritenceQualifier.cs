using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have attribute related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IInheritenceQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
