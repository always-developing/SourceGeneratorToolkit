namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The marked interface to indicate that a qualifier can have general modifiers applied to it
    /// </summary>
    /// <typeparam name="TQualifier">The qualifier type</typeparam>
    public interface IGeneralModifierQualifier<TQualifier> where TQualifier : QualfierBuilder
    {
    }
}
