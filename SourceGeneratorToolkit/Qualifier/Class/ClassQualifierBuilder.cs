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
        IHasAttributeQualifier<ClassQualifierBuilder>, IHasInheritenceQualifier<ClassQualifierBuilder>
    {
        /// <summary>
        /// Construnctor
        /// </summary>
        /// <param name="node">The syntax node being operated on</param>
        /// <param name="result">The result being built up</param>
        public ClassQualifierBuilder(SyntaxNode node, SyntaxReceiverResult result)
        {
            Node = node;
            Result = result;
            Qualifies = true;

            var classDeclaration = node as ClassDeclarationSyntax;
            Result.Metadata.Add(Metadata.ClassName, classDeclaration.Identifier.ToString());
        }
    }
}
