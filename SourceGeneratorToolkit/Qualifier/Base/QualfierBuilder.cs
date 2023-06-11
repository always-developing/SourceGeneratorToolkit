using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Base qualifier builder from qhich all other qualifiers inherit
    /// </summary>
    public abstract class QualfierBuilder
    {
        /// <summary>
        /// Flag to indicate if the node in question qualifies or not
        /// </summary>
        internal bool Qualifies { get; set; } = false;

        /// <summary>
        /// The node being tested for qualfication
        /// </summary>
        internal SyntaxNode Node { get; set; }
    }
}
