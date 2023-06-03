namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have attribute related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IHasAttributeQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
