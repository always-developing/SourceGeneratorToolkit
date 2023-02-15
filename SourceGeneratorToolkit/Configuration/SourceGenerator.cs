using Microsoft.CodeAnalysis;

namespace SourceGeneratorToolkit
{
    public static class SourceGenerator
    {
        public static GeneratorConfiguration ConfigureGenerator()
        {
            return new GeneratorConfiguration();
        }
    }
}
