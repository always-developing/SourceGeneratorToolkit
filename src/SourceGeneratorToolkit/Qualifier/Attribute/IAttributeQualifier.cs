namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Interface to indicate the parent can have attribute related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TBuilder">The qualifier builder</typeparam>
    public interface IAttributeQualifier<TBuilder> where TBuilder : QualfierBuilder
    {
    }
}
