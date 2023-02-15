using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class GeneratorExecutionContextExtensions
    {
        public static GeneratorConfiguration ConfigureGenerator(this GeneratorExecutionContext context)
        {
            return new GeneratorConfiguration();
        }
    }
}
