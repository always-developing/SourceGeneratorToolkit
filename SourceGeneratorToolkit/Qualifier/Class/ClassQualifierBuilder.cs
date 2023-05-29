using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassQualifierBuilder : QualfierBuilder, IAccessModifierQualifier<ClassQualifierBuilder>,
        IGeneralModifierQualifier<ClassQualifierBuilder>, INameQualifier<ClassQualifierBuilder>
    {
        public ClassQualifierBuilder(SyntaxNode node)
        {
            Node = node;
            Qualifies = true;
        }

        public ClassQualifierBuilder WithMethod(Action<MethodQualifierBuilder> builder)
        {
            if(!(Node is ClassDeclarationSyntax cls))
            {
                return this;
            }

            if (!cls.Members.Any())
            {
                Qualifies = false;
                return this;
            }

            var methodBuilder = new MethodQualifierBuilder(Node, Qualifies);

            builder.Invoke(methodBuilder);

            return this;
        }
    }
}
