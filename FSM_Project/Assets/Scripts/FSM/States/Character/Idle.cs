using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    public Idle()
    {

    }

    public void OnEnter()
    {
        Debug.Log("Enter Idle state");
    }

    public void OnExit()
    {
        Debug.Log("Exit Idle state");
    }

    public void Update()
    {
        
    }
}
