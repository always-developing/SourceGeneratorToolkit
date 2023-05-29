using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodQualifierBuilder : QualfierBuilder, IAccessModifierQualifier<MethodQualifierBuilder>,
        IGeneralModifierQualifier<MethodQualifierBuilder>, INameQualifier<MethodQualifierBuilder>
    {
        public MethodQualifierBuilder(SyntaxNode node, bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }
    }
}
