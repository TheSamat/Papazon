using System;
using System.Collections.Generic;

public class Program
{
}

class Base
{
    public virtual void M<T1, T2>() 
        where T1:struct 
    {    }
}
sealed class Derived : Base
{
    public override void M<T3, T2>()
        where T2: class
    {    }
}