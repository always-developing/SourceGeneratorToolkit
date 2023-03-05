using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;
public class Temp<T> : Task, IDisposable where T : new()
{
    public Temp(Action action) : base(action)
    {
    }
}
