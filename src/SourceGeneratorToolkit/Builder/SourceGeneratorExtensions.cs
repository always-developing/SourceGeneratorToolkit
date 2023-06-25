using Microsoft.CodeAnalysis;
using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the extending the .NET Source generator functionality
    /// </summary>
    public static class SourceGeneratorExtensions
    {
        /// <summary>
        /// Generate the source code on the context
        /// </summary>
        /// <param name="context">The generator execution context</param>
        /// <param name="fileName">The name of the file to create</param>
        /// <param name="builder">The builder for the source code</param>
        /// <param name="configurationBuilder">The configuration builder used to set build configuration</param>
        public static void GenerateSource(this GeneratorExecutionContext context, string fileName, Action<FileContainer> builder, 
            Action<BuilderConfiguration> configurationBuilder = null)
        {
            var configuration = new BuilderConfiguration();
            configurationBuilder?.Invoke(configuration);

            var fileContents = SourceGenerator.Generate(gen =>
            {
                gen.WithFile(fileName, builder);
            }).Build(configuration);

            context.AddSource(fileName, fileContents);
        }
    }
}
