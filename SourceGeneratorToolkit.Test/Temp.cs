//extern alias NS1;
//extern alias NS2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SourceGeneratorToolkit.Test;
public class Temp<T> : Task, IDisposable where T : new()
{
    public static readonly int myint = 100;

    public virtual int MyValue { get; set; } = 100;

    public Temp(Action action) : base(action)
    {
    }
}
