using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;

namespace SourceGeneratorToolkit
{
    public static class QualifierBuilderExtensions
    {
        public static SyntaxQualifierBuilder IsClass(this SyntaxQualifierBuilder syntaxBuilder, Action<ClassQualifierBuilder> builder = null)
        {
            if (!syntaxBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                return syntaxBuilder;
            }

            syntaxBuilder.Qualifies = true;

            if (builder != null)
            {
                var classBuilder = new ClassQualifierBuilder(syntaxBuilder.Node);

                builder?.Invoke(classBuilder);
                syntaxBuilder.Qualifies = classBuilder.Qualifies;
            }

            return syntaxBuilder;
        }

        public static SyntaxQualifierBuilder IsAttribute(this SyntaxQualifierBuilder syntaxBuilder, Action<AttributeQualifierBuilder> builder = null)
        {
            if (!syntaxBuilder.Node.IsKind(SyntaxKind.Attribute))
            {
                return syntaxBuilder;
            }

            syntaxBuilder.Qualifies = true;

            if (builder != null)
            {
                var attributeBuilder = new AttributeQualifierBuilder(syntaxBuilder.Node, syntaxBuilder.Qualifies);

                builder?.Invoke(attributeBuilder);
                syntaxBuilder.Qualifies = attributeBuilder.Qualifies;
            }

            return syntaxBuilder;
        }

        public static SyntaxQualifierBuilder WithQualifyingCheck(this SyntaxQualifierBuilder syntaxBuilder, Func<SyntaxNode, bool> builder = null)
        {
            if (builder != null)
            {
                var qualifies = builder.Invoke(syntaxBuilder.Node);
                if (syntaxBuilder.Qualifies && !qualifies)
                {
                    syntaxBuilder.Qualifies = false;
                }
            }

            return syntaxBuilder;
        }
    }
}
