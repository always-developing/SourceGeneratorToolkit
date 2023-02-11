﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class MethodModifierExtensions
    {
        public static MethodContainer AsPublic(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new PublicModifier());
            return container;
        }

        public static MethodContainer AsPrivate(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new PrivateModifier());
            return container;
        }

        public static MethodContainer AsProtected(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new ProtectedModifier());
            return container;
        }

        public static MethodContainer AsInternal(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new InternalModifier());
            return container;
        }

        public static MethodContainer AsPartial(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new PartialModifier());
            return container;
        }

        public static MethodContainer AsStatic(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new StaticModifier());
            return container;
        }

        public static MethodContainer AsAsync(this MethodContainer container)
        {
            container.Modifiers.SourceItems.Add(new AsyncModifier());
            return container;
        }
    }
}

