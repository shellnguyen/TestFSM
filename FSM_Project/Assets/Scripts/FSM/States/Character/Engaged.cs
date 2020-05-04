using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engaged : CharacterState
{
    public Engaged(CharacterController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        m_Controller.Animator.SetFloat("Speed", 0.0f);
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
        m_Controller.Attack();
        //m_Char.Explode();
    }
}
