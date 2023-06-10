using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public abstract class QualfierBuilder
    {
        internal bool Qualifies { get; set; } = false;

        internal SyntaxNode Node { get; set; }

        internal SyntaxReceiverResult Result { get; set; } = new SyntaxReceiverResult();
    }
}
