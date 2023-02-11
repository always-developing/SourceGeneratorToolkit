using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace SourceGeneratorToolkit
{
    public class GeneratorConfiguration
    {
        internal GeneratorExecutionContext Context { get; }

        public List<FileContainer> SourceItems;

        public GeneratorConfiguration(GeneratorExecutionContext context)
        {
            Context = context;

            SourceItems = new List<FileContainer>();
        }

        public void Build()
        {
            foreach (var file in SourceItems)
            {
                Context.AddSource(file.FileName, file.GenerateSource());
            }
        }

        
    }
}
