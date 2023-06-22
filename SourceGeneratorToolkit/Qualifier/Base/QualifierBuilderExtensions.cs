using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the root of qualification
    /// </summary>
    public static class QualifierBuilderExtensions
    {
        /// <summary>
        /// Checks if the node is a class
        /// </summary>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The class qualifier builder</param>
        /// <returns>The qualifier builder</returns>
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

        /// <summary>
        /// Checks if the node is an attribute
        /// </summary>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The attribute qualifier builder</param>
        /// <returns>The qualifier builder</returns>
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

        /// <summary>
        /// A
        /// </summary>
        /// <param name="syntaxBuilder"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
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
