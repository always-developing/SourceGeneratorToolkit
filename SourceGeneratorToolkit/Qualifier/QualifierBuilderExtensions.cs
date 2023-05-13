using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class QualifierBuilderExtensions
    {
        public static SyntaxQualifierBuilder IsClass(this SyntaxQualifierBuilder syntaxBuilder, Action<ClassQualifierBuilder> builder = null)
        {
            if (syntaxBuilder.Node is ClassDeclarationSyntax)
            {
                syntaxBuilder.Qualifies = true;
            }

            if (builder != null)
            {
                var classBuilder = new ClassQualifierBuilder(syntaxBuilder.Node);
                builder?.Invoke(classBuilder);
                syntaxBuilder.Qualifies = classBuilder.Qualifies;
            }

            return syntaxBuilder;
        }

        public static ClassQualifierBuilder WithName(this ClassQualifierBuilder syntaxBuilder, string className)
        {
            if (syntaxBuilder.Node is BaseTypeDeclarationSyntax declaration)
            {
                if (declaration.Identifier.ValueText == className)
                {
                    syntaxBuilder.Qualifies = true;
                }
            }

            return syntaxBuilder;
        }
    }
}
