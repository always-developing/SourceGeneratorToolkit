using SourceGeneratorToolkit.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SourceGeneratorToolkit
{
    public class ClassContainer : SourceContainer
    {
        internal override string Name => nameof(ClassContainer);

        internal AccessModifierStatement _accessModifier;

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        public ClassContainer(string className)
        {
            SourceText = className;
        }

        public override string ToSource()
        {
            var sb = new  IndentedStringBuilder(IndentLevel);

            sb.Append($"{_accessModifier?.ToSource()}");
            sb.Append(_generalModifiers.ToSource(), 0);


            sb.AppendLine($"class {SourceText}", 0);

            sb.Append(new BraceStartStatement().ToSource());
            sb.AppendLine(base.ToSource());
            sb.Append(new BraceEndStatement(0).ToSource());

            return sb.ToString();
        }

        public ClassContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement(); 
            return this; 
        }

        public ClassContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public ClassContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public ClassContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public ClassContainer AsFile()
        {
            _accessModifier = new FileModifierStatement();
            return this;
        }

        public ClassContainer AsAbstract()
        {
            _generalModifiers.SourceItems.Add(new AbstractModifierStatement());
            return this;
        }

        public ClassContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }

        public ClassContainer AsPartial()
        {
            _generalModifiers.SourceItems.Add(new PartialModifierStatement());
            return this;
        }

        public ClassContainer AsSealed()
        {
            _generalModifiers.SourceItems.Add(new SealedModifierStatement());
            return this;
        }
    }
}
