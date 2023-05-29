using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class CommonQualifierExtensions
    {
        public static TParent WithName<TParent>(this INameQualifier<TParent> syntaxBuilder, string className)
            where TParent : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TParent)syntaxBuilder;
            }

            if (qualifierBuilder.Node is BaseTypeDeclarationSyntax declaration)
            {
                qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && declaration.Identifier.ValueText == className;
            }

            return (TParent)syntaxBuilder;
        }
    }
}
