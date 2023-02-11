namespace SourceGeneratorToolkit
{
    public static class RawSourceExtensions
    {
        public static FileContainer WithRawSource(this FileContainer container, string sourceText, int order = 1)
        {
            container.SourceItems.Add(new RawSourceStatement(sourceText, order));

            return container;
        }

        public static NamespaceContainer WithRawSource(this NamespaceContainer container, string sourceText, int order = 1)
        {
            container.SourceItems.Add(new RawSourceStatement(sourceText, order));

            return container;
        }
    }
}
