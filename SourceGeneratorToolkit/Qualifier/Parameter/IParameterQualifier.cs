namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Marker interface to indicate the parent can have parameter related qualifiing methods applied
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public interface IParameterQualifier<TParent> where TParent : QualfierBuilder
    {
    }
}
