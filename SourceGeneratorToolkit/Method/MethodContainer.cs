using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class MethodContainer : SourceContainer
    {
        internal override string Name => nameof(MethodContainer);

        internal ParameterContainer _parameterContainer = new ParameterContainer();

        internal ModifierContainer _generalModifiers = new ModifierContainer();

        internal AccessModifierStatement _accessModifier;

        internal GenericsContainer _genericsContainer = new GenericsContainer();

        internal GenericsConstraintContainer _constraintContainer = new GenericsConstraintContainer();

        internal string _returnType;

        public MethodContainer(string methodName, string returnType)
        {
            SourceText = methodName;
            _returnType = returnType;
        }

        public override string ToSource()
        {
            var tempList = new List<SourceStatement>();

            tempList.Add(new NewLineStatement());

            if (_accessModifier != null)
            {
                tempList.Add(_accessModifier);
            }

            tempList.Add(_generalModifiers);
            tempList.Add(new Statement($"{_returnType} {SourceText}"));
            tempList.Add(_genericsContainer);
            tempList.Add(new ParenthesisStartStatement());
            tempList.Add(_parameterContainer);
            tempList.Add(new ParenthesisEndStatement());
            tempList.Add(_constraintContainer);
            tempList.Add(new BraceStartStatement());

            SourceItems.InsertRange(0, tempList);

            SourceItems.Add(new BraceEndStatement());

            return base.ToSource();
        }

        public MethodContainer AsPublic()
        {
            _accessModifier = new PublicModifierStatement();
            return this;
        }

        public MethodContainer AsPrivate()
        {
            _accessModifier = new PrivateModifierStatement();
            return this;
        }

        public MethodContainer AsProtected()
        {
            _accessModifier = new ProtectedModifierStatement();
            return this;
        }

        public MethodContainer AsInternal()
        {
            _accessModifier = new InternalModifierStatement();
            return this;
        }

        public MethodContainer AsAbstract()
        {
            _generalModifiers.SourceItems.Add(new AbstractModifierStatement());
            return this;
        }

        public MethodContainer AsStatic()
        {
            _generalModifiers.SourceItems.Add(new StaticModifierStatement());
            return this;
        }

        public MethodContainer AsPartial()
        {
            _generalModifiers.SourceItems.Add(new PartialModifierStatement());
            return this;
        }

        public MethodContainer AddGeneric(string value)
        {
            _genericsContainer.SourceItems.Add(new GenericContainer(value));
            return this;
        }

        public MethodContainer WithGenericConstraint(string generic, string constraint)
        {
            _constraintContainer.AddConstraint(generic, constraint);

            return this;
        }
    }
}
