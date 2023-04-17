//extern alias NS1;
//extern alias NS2;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SourceGeneratorToolkit.Test
{
    public struct MyStruct<T> where T : new()
    {
    }

    public abstract record MyRec(string Name)
    {
        public Guid Id { get; private protected init ; }

    }

    public class myclass
    {
        private protected myclass()
        {
            
        }
    }

}

public abstract class Temp<T> : Task, IDisposable where T : new()
{
    public abstract int myint = 100;

    public abstract int MyValue { get; set; }

    public Temp(Action action) : base(action)
    {
    }
}

partial interface ITemp<T>
{
    public abstract int MyMethod();
}
