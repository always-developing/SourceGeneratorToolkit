﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SourceGeneratorToolkit
{
    public static class AccessModifierQualifierExtensions
    {
        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }
        
        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAccessModifiers(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyAccessModifier(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyAccessModifier(qualifierBuilder, accessModifiers);
        }
    }
}
