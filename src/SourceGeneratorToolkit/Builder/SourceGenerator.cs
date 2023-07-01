using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The base generator class from which all generation occurs
    /// </summary>
    public class SourceGenerator
    {
        private readonly Action<Generator> _rootGenerator;

        /// <summary>
        /// Generate the source using the builder and configuration specified
        /// </summary>
        /// <param name="builder">The builder parameters</param>
        /// <param name="configuration">The configuration settings</param>
        /// <returns>A string representation of the generated code</returns>
        public static string GenerateSource(Action<Generator> builder, BuilderConfiguration configuration = null)
        {
            var generator = SourceGenerator.Generate(builder);
            return generator.Build(configuration);
        }

        /// <summary>
        /// Constructor for SourceGenerator
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the root source generation</param>
        internal SourceGenerator(Action<Generator> builder)
        {
            _rootGenerator = builder;
        }

        /// <summary>
        /// The root method from which source generation will occur
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the root source generation</param>
        /// <returns>The generated source</returns>
        internal static SourceGenerator Generate(Action<Generator> builder)
        {
            return new SourceGenerator(builder);
        }

        /// <summary>
        /// Invokes the generation actions to build and output the source code
        /// </summary>
        /// <returns>The generated, formatted source code</returns>
        internal string Build(BuilderConfiguration configuration = null)
        {
            var gen = new Generator(configuration ?? new BuilderConfiguration());
            _rootGenerator.Invoke(gen);

            return CSharpSyntaxTree.ParseText(gen.ToSource()).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();

        }

        /// <summary>
        /// Generates a tree view heirarchy of the source code
        /// </summary>
        /// <returns>The source code heirarchy</returns>
        public string ToTree()
        {
            var gen = new Generator(default);
            _rootGenerator.Invoke(gen);

            return gen.ToTree(1);
        }
    }
}
