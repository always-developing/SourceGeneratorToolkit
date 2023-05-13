namespace SourceGeneratorToolkit
{
    internal class TaskStatement : SourceContainer
    {
        internal override string Name => nameof(TaskStatement);

        public TaskStatement()
        {
            SourceText = string.Empty;
        }

        public TaskStatement(string type)
        {
            SourceText = type;
        }

        public override string ToSource()
        {
            _sourceItems.Add(new Statement("Task"));

            if (!string.IsNullOrEmpty(SourceText))
            {
                _sourceItems.Add(new ChevronStartStatement());
                _sourceItems.Add(new Statement(SourceText));
                _sourceItems.Add(new ChevronEndStatement());
            }

            return base.ToSource();
        }
    }
}
