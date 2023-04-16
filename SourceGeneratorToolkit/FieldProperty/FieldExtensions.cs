using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class FieldExtensions
    {
        public static T AddField<T>(this ISupportsField<T> @base, string type, string name, Action<FieldContainer> builder = null) where T : SourceContainer
        {
            @base.Fields.AddField(type, name, builder);
            return (T)@base;
        }

        public static T AddField<T>(this ISupportsField<T> @base, Type type, string name, Action<FieldContainer> builder = null) where T : SourceContainer
        {
            @base.Fields.AddField(type.Name, name, builder);
            return (T)@base;
        }
    }
}
