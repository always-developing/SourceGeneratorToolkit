namespace SourceGeneratorToolkit
{
    public static class ClassModifierExtensions
    {
        public static ClassContainer AsPublic(this ClassContainer container)
        {
            container.Modifiers.Add(new PublicModifier());
            return container;
        }

        public static ClassContainer AsPrivate(this ClassContainer container)
        {
            container.Modifiers.Add(new PrivateModifier());
            return container;
        }

        public static ClassContainer AsProtected(this ClassContainer container)
        {
            container.Modifiers.Add(new ProtectedModifier());
            return container;
        }

        public static ClassContainer AsInternal(this ClassContainer container)
        {
            container.Modifiers.Add(new InternalModifier());
            return container;
        }

        public static ClassContainer AsPartial(this ClassContainer container)
        {
            container.Modifiers.Add(new PartialModifier());
            return container;
        }

        public static ClassContainer AsStatic(this ClassContainer container)
        {
            container.Modifiers.Add(new StaticModifier());
            return container;
        }
    }
}
