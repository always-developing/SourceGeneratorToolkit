using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace SourceGeneratorToolkit
{
    public class SourceGenerator
    {
        private readonly Action<Generator> _rootGenerator;

        public SourceGenerator(Action<Generator> root)
        {
            _rootGenerator = root;
        }

        public static SourceGenerator Generate(Action<Generator> root)
        {
            return new SourceGenerator(root);
        }

        public string Build()
        {
            var gen = new Generator();
            _rootGenerator.Invoke(gen);

            return CSharpSyntaxTree.ParseText(gen.ToSource()).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();

        }

        public string ToTree()
        {
            var gen = new Generator();
            _rootGenerator.Invoke(gen);

            return gen.ToTree(1);
        }
    }
}
