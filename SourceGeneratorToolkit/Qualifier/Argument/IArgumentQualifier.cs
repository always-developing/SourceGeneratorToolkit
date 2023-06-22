namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have argument related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IArgumentQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
