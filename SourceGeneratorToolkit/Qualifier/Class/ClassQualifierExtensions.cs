using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{
    public static class ClassQualifierExtensions
    {
        public static ClassQualifierBuilder WithName(this ClassQualifierBuilder syntaxBuilder, string className)
        {
            if (!syntaxBuilder.Qualifies)
            {
                return syntaxBuilder;
            }

            if (syntaxBuilder.Node is BaseTypeDeclarationSyntax declaration)
            {
                syntaxBuilder.Qualifies = syntaxBuilder.Qualifies && declaration.Identifier.ValueText == className;
            }

            return syntaxBuilder;
        }
    }
}
