using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for argument related qualifier
    /// </summary>
    public static class ArgumentQualifierExtensions
    {
        /// <summary>
        /// Checks if the node has an argument with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithArgument<TBuilder>(this IHasArgumentQualifier<TBuilder> syntaxBuilder, Action<ArgumentQualifierBuilder> builder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (qualifierBuilder.Node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.Attribute))
            {
                var attribute = qualifierBuilder.Node as AttributeSyntax;
                var arguments = attribute.ArgumentList?.Arguments;

                if (arguments == null || (arguments.HasValue && !arguments.Value.Any()))
                {
                    qualifierBuilder.Qualifies = false;
                    return (TBuilder)qualifierBuilder;
                }

                bool argumentQualifies = false;
                foreach (AttributeArgumentSyntax argument in arguments)
                {
                    var argumentQualifier = new ArgumentQualifierBuilder(argument, qualifierBuilder.Qualifies);
                    builder(argumentQualifier);
                    
                    if(argumentQualifier.Qualifies)
                    {
                        argumentQualifies = true;
                    }
                }

                if (argumentQualifies)
                {
                    qualifierBuilder.Qualifies = true;
                    return (TBuilder)qualifierBuilder;
                }
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        /// <summary>
        /// Checks if the node has an argument with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="name">The argument name</param>
        /// <param name="value">The argument value</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithNameAndValue<TBuilder>(this IArgumentQualifier<TBuilder> syntaxBuilder, string name, string value)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var argName = GetNodeName(qualifierBuilder.Node);
            var argValue = GetNodeValue(qualifierBuilder.Node);

            if (name.Equals(argName) && value.Equals(argValue))
            {
                qualifierBuilder.Qualifies = true;
                return (TBuilder)qualifierBuilder;
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        /// <summary>
        /// Checks if the node has an argument with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="value">The argument value</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithValue<TBuilder>(this IArgumentQualifier<TBuilder> syntaxBuilder, string value)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var argValue = GetNodeValue(qualifierBuilder.Node);

            if (value.Equals(argValue))
            {
                qualifierBuilder.Qualifies = true;
                return (TBuilder)qualifierBuilder;
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        public static TBuilder WithPosition<TBuilder>(this IArgumentQualifier<TBuilder> syntaxBuilder, int position)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var argPosition = GetNodePosition(qualifierBuilder.Node);

            if (position == argPosition)
            {
                qualifierBuilder.Qualifies = true;
                return (TBuilder)qualifierBuilder;
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        private static string GetNodeName(SyntaxNode node) =>
            node switch
            {
                AttributeArgumentSyntax argument => argument.NameColon != null ? argument.NameColon.Name.Identifier.ValueText : string.Empty,
                null => default,
                _ => default
            };

        private static string GetNodeValue(SyntaxNode node) =>
            node switch
            {
                AttributeArgumentSyntax argument => StripStringQuotes(argument.Expression.ToString()),
                null => default,
                _ => default
            };

        private static int GetNodePosition(SyntaxNode node) =>
            node switch
            {
                AttributeArgumentSyntax argument => GetAttributeArgumentPosition(argument),
                null => default,
                _ => default
            };

        private static int GetAttributeArgumentPosition(AttributeArgumentSyntax argument)
        {
            if (argument.Parent is AttributeArgumentListSyntax argList)
            {
                var index = argList.Arguments.IndexOf(argument);
                
                return index >= 0 ? index + 1 : -1;
            }

            return -1;
        }

        private static string StripStringQuotes(string value)
        {
            if(value.StartsWith("\"") && value.EndsWith("\""))
            {
                return value.AsSpan().Slice(1, value.Length - 2).ToString();
            }

            return value;
        }
    }
}
