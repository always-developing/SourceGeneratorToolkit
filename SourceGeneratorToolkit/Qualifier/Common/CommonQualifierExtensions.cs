using Microsoft.CodeAnalysis;
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

            qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && GetNodeIdentifier(qualifierBuilder.Node) == className;

            return (TParent)syntaxBuilder;
        }

        private static string GetNodeIdentifier(SyntaxNode node) =>
            node switch
            {
                BaseTypeDeclarationSyntax baseDeclaration => baseDeclaration.Identifier.ValueText,
                MethodDeclarationSyntax methodDeclaration => methodDeclaration.Identifier.ValueText,
                null => string.Empty,
                _ => string.Empty
            };
    }
}
