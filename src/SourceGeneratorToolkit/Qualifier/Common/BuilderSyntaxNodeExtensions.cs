using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for syntax nodes
    /// </summary>
    public static class BuilderSyntaxNodeExtensions
    {
        /// <summary>
        /// Return the Syntax node as a class
        /// </summary>
        /// <param name="node">The node in question</param>
        /// <returns>The node as a class declaration syntax</returns>
        public static ClassDeclarationSyntax AsClass(this SyntaxNode node)
        {
            if(node.IsKind(SyntaxKind.ClassDeclaration))
            {
                return (ClassDeclarationSyntax)node;
            }

            return null;
        }

        /// <summary>
        /// Return the Syntax node as an attribute
        /// </summary>
        /// <param name="node">The node in question</param>
        /// <returns>The node as a attribute syntax</returns>
        public static AttributeSyntax AsAttribute(this SyntaxNode node)
        {
            if (node.IsKind(SyntaxKind.Attribute))
            {
                return (AttributeSyntax)node;
            }

            return null;
        }

        /// <summary>
        /// Get the underlying name of the node type. E.g. for a ClassDeclarationSyntax, this will return the class name.
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>The name of the node type</returns>
        public static string GetName(this SyntaxNode node)
        {
            return CommonQualifierExtensions.GetNodeIdentifier(node);
        }

        /// <summary>
        /// Gets the root namespace of the node (if one is present)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string GetNamespace(this SyntaxNode node) =>
            node.Parent switch
            {
                NamespaceDeclarationSyntax namespaceDeclarationSyntax => namespaceDeclarationSyntax.Name.ToString(),
                FileScopedNamespaceDeclarationSyntax fsnamespaceDeclarationSyntax => fsnamespaceDeclarationSyntax.Name.ToString(),
                null => string.Empty,
                _ => GetNamespace(node.Parent)
            };

        /// <summary>
        /// Try get the namespace for a given node. 
        /// </summary>
        /// <param name="node">The node to get the namespace for</param>
        /// <param name="rootNamespace">The namespace found (empty if not namespace)</param>
        /// <returns>True if a namespace was found, false otherwise</returns>
        public static bool TryGetNamespace(this SyntaxNode node, out string rootNamespace)
        {
            switch (node.Parent)
            {
                case NamespaceDeclarationSyntax ns:
                    rootNamespace = ns.Name.ToString();
                    return true;
                case FileScopedNamespaceDeclarationSyntax fns:
                    rootNamespace = fns.Name.ToString();
                    return true;
                case null:
                    rootNamespace = string.Empty;
                    return false;
                default:
                    GetNamespace(node.Parent);
                        break;
            }

            rootNamespace = string.Empty;
            return false;
        }
    }
}
