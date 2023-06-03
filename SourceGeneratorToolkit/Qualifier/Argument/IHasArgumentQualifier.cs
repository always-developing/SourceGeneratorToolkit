using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have base argument related qualfiier applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IHasArgumentQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
