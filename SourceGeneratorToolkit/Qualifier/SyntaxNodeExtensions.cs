using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
            syntaxBuilder.Result.Metadata.Add(Metadata.Namespace, node.GetNamespaceRoot());

            builder.Invoke(syntaxBuilder);

            if(syntaxBuilder.Qualifies)
            {
                //TODO - sort out custom metadata
                syntaxBuilder.Result.Node = node;
                results.Add(syntaxBuilder.Result);
            }

            return syntaxBuilder.Qualifies;
        }

        public static string GetNamespaceRoot(this SyntaxNode node) =>
            node.Parent switch
            {
                // TODO - does this work on attribute?
                NamespaceDeclarationSyntax namespaceDeclarationSyntax => namespaceDeclarationSyntax.Name.ToString(),
                FileScopedNamespaceDeclarationSyntax fsnamespaceDeclarationSyntax => fsnamespaceDeclarationSyntax.Name.ToString(),
                null => string.Empty, 
                _ => GetNamespaceRoot(node.Parent)
            };

        public static SyntaxReceiverResult BuildResult(this SyntaxNode node, Dictionary<string, string> metadata, Func<SyntaxNode, Dictionary<string, object>> customMetadataBuilder = null)
        {
            var customMetadata = customMetadataBuilder?.Invoke(node);

            return new SyntaxReceiverResult
            {
                Node = node,
                Metadata = metadata,
                CustomMetadata = customMetadata
                //Name = GetNodeName(node),
                //Namespace = node.GetNamespaceRoot(),
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
