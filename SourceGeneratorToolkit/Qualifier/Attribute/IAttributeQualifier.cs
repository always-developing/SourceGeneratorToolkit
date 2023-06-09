namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Interface to indicate the parent can have attribute related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IAttributeQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
