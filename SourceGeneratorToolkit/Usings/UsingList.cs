﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public class UsingList : SourceContainer
    {
        internal override string Name => nameof(UsingList);

        public UsingContainer AddUsing(string @using, Action<UsingContainer> builder = null)
        {
            var usingContainer = new UsingContainer(@using);
            _sourceItems.Add(usingContainer);

            builder?.Invoke(usingContainer);

            return usingContainer;
        }

        public override string ToSource()
        {
            _sourceItems = _sourceItems
                .Select(s => s as UsingContainer)
                .ToList()
                .OrderByDescending(s => s._isGlobal)
                .ThenBy(s => s.SourceText)
                .Select(s => s as SourceStatement)
                .ToList();

            return base.ToSource();
        }
    }
}