﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal static class ConfigurationExtensions
    {
        internal static void AddGenerateCodeAttribute(this ClassContainer container)
        {
            AddGenerateAttribute<ClassContainer>(container);
        }

        internal static void AddGenerateCodeAttribute(this InterfaceContainer container)
        {
            AddGenerateAttribute<InterfaceContainer>(container);
        }

        private static void AddGenerateAttribute<TParent>(SourceStatement container) where TParent : SourceContainer
        {
            if (container.Configuration.OutputGeneratedCodeAttribute)
            {
                if (container is ISupportsAttributes<TParent> attContainer)
                {
                    attContainer.AddAttribute("System.CodeDom.Compiler.GeneratedCodeAttribute", att =>
                    {
                        att.AddArgument("\"SourceGeneratorToolkit\"");
                        att.AddArgument($"\"{typeof(ConfigurationExtensions).Assembly.GetName().Version}\"");
                    });
                }
            }
        }
    }
}
