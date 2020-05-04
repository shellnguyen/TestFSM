using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] private Vector3 m_Movement;
    [SerializeField] private float m_Speed;
    [SerializeField] private bool m_IsMove;

    protected override void Initialize()
    {
        base.Initialize();
        m_Speed = 3.0f;
        m_IsMove = false;
    }

    protected override void SetupStates()
    {
        base.SetupStates();

        Idle idleState = new Idle(this);
        Walking walkingState = new Walking(this);

        m_StateMachine.AddTransition(idleState, walkingState, IsWalking);
        m_StateMachine.AddTransition(walkingState, idleState, IsIdle);

        m_StateMachine.SetState(idleState);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Initialize();
        SetupStates();
        //m_Detector.ParentTag = this.tag;
        //m_RB = this.GetComponent<Rigidbody>();
        //m_Animator = this.GetComponent<Animator>();

        //m_StateMachine = new StateMachine();

        //Idle idleState = new Idle();
        //Pursue pursueState = new Pursue(m_Detector, m_NavMeshAgent);
        //Engaged engagedState = new Engaged(this);

        //m_StateMachine.AddTransition(idleState, pursueState, HasTarget);
        //m_StateMachine.AddTransition(pursueState, idleState, LostTarget);
        //m_StateMachine.AddTransition(pursueState, engagedState, ReachedTarget);

        //m_StateMachine.SetState(idleState);
    }

    private bool IsWalking()
    {
        return m_IsMove;
    }

    private bool IsIdle()
    {
        return !m_IsMove;
    }

    private void FixedUpdate()
    {
        MoveCharacter(m_Movement);
    }

    // Update is called once per frame
    private void Update()
    {
        //m_Movement.x = Input.GetAxis("Horizontal");
        //m_Movement.z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            m_IsMove = true;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_IsMove = false;
        }

        m_Movement = ((Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"))).normalized;
        
        if(m_Detector.Target)
        {
            Debug.Log("See " + m_Detector.Target.name);
        }

        m_StateMachine.Update();
    }

    private void MoveCharacter(Vector3 direction)
    {
        m_RB.MovePosition(transform.position + (direction * m_Speed * Time.deltaTime));
    }
}
