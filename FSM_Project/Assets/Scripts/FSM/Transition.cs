using System;
using System.Collections;
using System.Collections.Generic;

public class Transition
{
    public IState To { get; }
    public Func<bool> Condition { get; }

    public Transition(IState to, Func<bool> predicate)
    {
        this.To = to;
        this.Condition = predicate;
    }
}
