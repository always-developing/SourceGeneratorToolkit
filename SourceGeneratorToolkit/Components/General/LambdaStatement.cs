namespace SourceGeneratorToolkit
{
    internal class LambdaStatement : SourceStatement
    {
        public override string Name => nameof(LambdaStatement);

        public override int Order { get; set; } = 0;

        private const string _lambda = " =>";

        public LambdaStatement()
        {
            SourceText = _lambda;
        }
    }
}