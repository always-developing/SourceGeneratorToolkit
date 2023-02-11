using System.Text;

namespace SourceGeneratorToolkit
{
    public class ParameterContainer : SourceContainer
    {
        public override string Name => nameof(ParameterContainer);

        public override int Order { get; set; } = 1;

        public override string GenerateSource()
        {
            var sb = new StringBuilder();

            for(var i = 0; i < SourceItems.Count; i++)
            {
                var parameter = SourceItems[i];

                sb.Append($"{parameter.GenerateSource()}");

                if (i != SourceItems.Count - 1)
                {
                    sb.Append($", ");
                }
            }

            return sb.ToString();
        }
    }
}
