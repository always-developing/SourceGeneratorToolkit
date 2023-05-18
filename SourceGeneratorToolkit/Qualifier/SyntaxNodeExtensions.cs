using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    public static class SyntaxNodeExtensions
    {
        public static bool NodeQualifiesWhen(this SyntaxNode node, List<SyntaxReceiverResult> results, 
            Action<SyntaxQualifierBuilder> builder,
            Func<SyntaxNode, Dictionary<string, object>> customMetadataBuilder = null)
        {
            var syntaxBuilder = new SyntaxQualifierBuilder(node);
            builder.Invoke(syntaxBuilder);

            if(syntaxBuilder.Qualifies)
            {
                results.Add(node.BuildResult(customMetadataBuilder));
            }

            return syntaxBuilder.Qualifies;
        }

        public static string GetNamespaceRoot(this SyntaxNode node) =>
            node.Parent switch
            {
                NamespaceDeclarationSyntax namespaceDeclarationSyntax => namespaceDeclarationSyntax.Name.ToString(),
                FileScopedNamespaceDeclarationSyntax fsnamespaceDeclarationSyntax => fsnamespaceDeclarationSyntax.Name.ToString(),
                null => string.Empty, 
                _ => GetNamespaceRoot(node.Parent)
            };

        public static SyntaxReceiverResult BuildResult(this SyntaxNode node, Func<SyntaxNode, Dictionary<string, object>> customMetadataBuilder = null)
        {
            var metadata = customMetadataBuilder?.Invoke(node);

            return new SyntaxReceiverResult
            {
                Node = node,
                Name = GetNodeName(node),
                Namespace = node.GetNamespaceRoot(),
                CustomMetadata = metadata
            };
        }

        private static string GetNodeName(SyntaxNode node)
        {
            var name = string.Empty;

            switch (node)
            {
                case BaseTypeDeclarationSyntax bds:
                    name = bds.Identifier.ValueText.ToString();
                    break;
                default:
                    break;
            }

            return name;
        }

    }
}
