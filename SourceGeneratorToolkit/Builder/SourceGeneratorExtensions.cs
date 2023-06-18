using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class SourceGeneratorExtensions
    {
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
