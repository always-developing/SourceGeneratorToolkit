namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have parameter related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IParameterQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
