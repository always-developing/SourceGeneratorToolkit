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
        /// Constructor for SourceGenerator
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the root source generation</param>
        public SourceGenerator(Action<Generator> builder)
        {
            _rootGenerator = builder;
        }

        /// <summary>
        /// The root method from which source generation will occur
        /// </summary>
        /// <param name="builder">The builder used to modify the properties of the root source generation</param>
        /// <returns>The generated source</returns>
        public static SourceGenerator Generate(Action<Generator> builder)
        {
            return new SourceGenerator(builder);
        }

        /// <summary>
        /// Invokes the generation actions to build and output the source code
        /// </summary>
        /// <returns>The generated, formatted source code</returns>
        public string Build()
        {
            var gen = new Generator();
            _rootGenerator.Invoke(gen);

            return CSharpSyntaxTree.ParseText(gen.ToSource()).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();

        }

        /// <summary>
        /// Generates a tree view heirarchy of the source code
        /// </summary>
        /// <returns>The source code heirarchy</returns>
        public string ToTree()
        {
            var gen = new Generator();
            _rootGenerator.Invoke(gen);

            return gen.ToTree(1);
        }
    }
}
