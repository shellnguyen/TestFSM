using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : IState
{
    protected CharacterController m_Controller;

    public CharacterState(CharacterController controller)
    {
        m_Controller = controller;
    }

    public virtual void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
