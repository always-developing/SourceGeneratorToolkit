namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have argument related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IArgumentQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
