namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have attribute related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IHasAttributeQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
