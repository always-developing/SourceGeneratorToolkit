using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The qualifier builder for classes
    /// </summary>
    public class ClassQualifierBuilder : QualfierBuilder, IAccessModifierQualifier<ClassQualifierBuilder>,
        IGeneralModifierQualifier<ClassQualifierBuilder>, INameQualifier<ClassQualifierBuilder>, IMethodQualifier<ClassQualifierBuilder>,
        IHasAttributeQualifier<ClassQualifierBuilder>
    {
        /// <summary>
        /// Construnctor
        /// </summary>
        /// <param name="node">The node being checked for qualification</param>
        public ClassQualifierBuilder(SyntaxNode node)
        {
            Node = node;
            Qualifies = true;
        }
    }
}
