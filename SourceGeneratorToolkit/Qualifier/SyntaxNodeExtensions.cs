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
            builder.Invoke(syntaxBuilder);

            if(syntaxBuilder.Qualifies)
            {
                results.Add(node.BuildResult(customMetadataBuilder));
            }

            return syntaxBuilder.Qualifies;
        }

        public static SyntaxReceiverResult BuildResult(this SyntaxNode node, Func<SyntaxNode, Dictionary<string, object>> customMetadataBuilder = null)
        {
            var customMetadata = customMetadataBuilder?.Invoke(node);

            return new SyntaxReceiverResult
            {
                Node = node,
                CustomMetadata = customMetadata
                //Name = GetNodeName(node),
                //Namespace = node.GetNamespaceRoot(),
            };
        }

        //private static string GetNodeName(SyntaxNode node)
        //{
        //    var name = string.Empty;

        //    switch (node)
        //    {
        //        case BaseTypeDeclarationSyntax bds:
        //            name = bds.Identifier.ValueText.ToString();
        //            break;
        //        default:
        //            break;
        //    }

        //    return name;
        //}

    }
}
