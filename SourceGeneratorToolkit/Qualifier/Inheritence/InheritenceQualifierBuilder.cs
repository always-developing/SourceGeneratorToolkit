using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Qualifier for inheritence
    /// </summary>
    public class InheritenceQualifierBuilder : QualfierBuilder, INameQualifier<InheritenceQualifierBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node being tested for qualification</param>
        /// <param name="qualifies">Bool to indicate the starting qualification state</param>
        public InheritenceQualifierBuilder(SyntaxNode node, bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }
    }
}
