using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : IState
{
    private Animator m_Animator;

    public Walking(Animator anim)
    {
        m_Animator = anim;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
