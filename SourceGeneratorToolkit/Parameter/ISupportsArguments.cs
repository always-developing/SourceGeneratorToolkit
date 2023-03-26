﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit
{
    public interface ISupportsArguments<T> where T : SourceContainer
    {
        ArgumentList Arguments { get; }
    }
}