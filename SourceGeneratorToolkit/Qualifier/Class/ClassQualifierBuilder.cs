﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class ClassQualifierBuilder : QualfierBuilder, IAccessModifierQualifier<ClassQualifierBuilder>
    {
        public ClassQualifierBuilder(SyntaxNode node)
        {
            Node = node;
            Qualifies = true;
        }
    }
}
