using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class SourceGeneratorExtensions
    {
        public static void GenerateSource(this GeneratorExecutionContext context, string fileName, Action<FileContainer> builder)
        {
            var fileContents = SourceGenerator.Generate(gen =>
            {
                gen.WithFile(fileName, builder);
            }).Build();

            context.AddSource(fileName, fileContents);
        }
    }
}
