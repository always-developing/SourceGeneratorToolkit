namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The marked interface to indicate that a qualifier can have access modifiers applied to it
    /// </summary>
    /// <typeparam name="TQualifier">The qualifier type</typeparam>
    public interface IAccessModifierQualifier<TQualifier> where TQualifier : QualfierBuilder
    {
    }
}
