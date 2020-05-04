using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : CharacterState
{
    public Idle(CharacterController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Enter Idle state");
        m_Controller.Animator.SetFloat("Speed", 0.0f);
    }

    public override void OnExit()
    {
        Debug.Log("Exit Idle state");
    }

    public override void Update()
    {
        
    }
}
