using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class AccessModifierContainer : SourceContainer
    {
        internal override string Name => nameof(AccessModifierContainer);

        internal T AsPublic<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new PublicModifierStatement());

            return parent;
        }

        internal T AsPrivate<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new PrivateModifierStatement());

            return parent;
        }

        internal T AsProtected<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new ProtectedModifierStatement());

            return parent;
        }

        internal T AsInternal<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new InternalModifierStatement());

            return parent;
        }

        internal T AsFile<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new FileModifierStatement());

            return parent;
        }

        internal T AsProtectedInternal<T>(T parent) where T : SourceContainer
        {
            _sourceItems.Clear();
            _sourceItems.Add(new ProtectedInternalModifierStatement());

            return parent;
        }
    }
}
