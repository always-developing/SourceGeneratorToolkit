using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extensions methods for a syntax node when performing qualfications
    /// </summary>
    public static class SyntaxNodeExtensions
    {
        /// <summary>
        /// The start of the qualification process to determine if a node qualifies resulting in source code being generated
        /// </summary>
        /// <param name="node">The node in question</param>
        /// <param name="results">The results from the qualification process</param>
        /// <param name="builder">The qualification builder</param>
        /// <param name="customMetadataBuilder">A func which allows for custom metadata to be set</param>
        /// <returns>A flag indicating if the qualification process was successful or not</returns>
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

        /// <summary>
        /// Builds up the results from a qualfication check
        /// </summary>
        /// <param name="node">The syntax node being checked</param>
        /// <param name="customMetadataBuilder">The custom meta data builder</param>
        /// <returns>The results from the qualification check</returns>
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
       
    }
}
