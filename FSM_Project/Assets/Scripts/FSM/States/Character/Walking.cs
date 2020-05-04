using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : CharacterState
{
    public Walking(CharacterController controller) : base(controller)
    {
    }

    //private CharacterController m_Controller;

    public override void OnEnter()
    {
        Debug.Log("WTF");
        m_Controller.Animator.SetFloat("Speed", 1.0f);
    }

    public override void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public override void Update()
    {
        
    }
}
