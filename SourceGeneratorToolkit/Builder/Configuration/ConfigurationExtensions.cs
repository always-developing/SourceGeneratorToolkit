using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    internal static class ConfigurationExtensions
    {
        internal static void AddBuildConfigurationOptions(this ClassContainer container)
        {
            AddGenerateAttribute<ClassContainer>(container);
            AddStepThroughAttribute<ClassContainer>(container);
        }

        internal static void AddBuildConfigurationOptions(this InterfaceContainer container)
        {
            AddGenerateAttribute<InterfaceContainer>(container);
            AddStepThroughAttribute<InterfaceContainer>(container);
        }

        internal static void AddBuildConfigurationOptions(this EnumContainer container)
        {
            AddGenerateAttribute<EnumContainer>(container);
            AddStepThroughAttribute<EnumContainer>(container);
        }

        internal static void AddBuildConfigurationOptions(this RecordContainer container)
        {
            AddGenerateAttribute<RecordContainer>(container);
            AddStepThroughAttribute<RecordContainer>(container);
        }

        internal static void AddBuildConfigurationOptions(this StructContainer container)
        {
            AddGenerateAttribute<StructContainer>(container);
            AddStepThroughAttribute<StructContainer>(container);
        }

        private static void AddGenerateAttribute<TParent>(SourceStatement container) where TParent : SourceContainer
        {
            if (container.Configuration.OutputGeneratedCodeAttribute)
            {
                if (container is ISupportsAttributes<TParent> attContainer)
                {
                    attContainer.AddAttribute("System.CodeDom.Compiler.GeneratedCode", att =>
                    {
                        att.AddArgument("\"SourceGeneratorToolkit\"");
                        att.AddArgument($"\"{typeof(ConfigurationExtensions).Assembly.GetName().Version}\"");
                    });
                }
            }
        }

        private static void AddStepThroughAttribute<TParent>(SourceStatement container) where TParent : SourceContainer
        {
            if (container.Configuration.OutputDebuggerStepThroughAttribute)
            {
                if (container is ISupportsAttributes<TParent> attContainer)
                {
                    attContainer.AddAttribute("System.Diagnostics.DebuggerStepThrough");
                }
            }
        }
    }
}
