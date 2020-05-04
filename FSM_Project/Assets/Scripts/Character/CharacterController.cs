using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody m_RB;
    [SerializeField] protected Animator m_Animator;
    [SerializeField] protected Detector m_Detector;
    protected StateMachine m_StateMachine;

    public Animator Animator
    {
        get
        {
            return m_Animator;
        }
    }

    public Detector Detector
    {
        get
        {
            return m_Detector;
        }
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return m_RB;
        }
    }

    protected virtual void Initialize()
    {
        m_Detector.ParentTag = this.tag;
        m_RB = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        m_StateMachine = new StateMachine();
    }

    protected virtual void SetupStates()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Pursue()
    {

    }
}
