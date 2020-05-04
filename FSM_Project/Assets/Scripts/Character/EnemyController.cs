using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterController
{
    [SerializeField] private NavMeshAgent m_NavMeshAgent;
    [SerializeField] private GameObject m_ExplosionPrefab;

    public NavMeshAgent NavMeshAgent
    {
        get
        {
            return m_NavMeshAgent;
        }
    }

    protected override void Initialize()
    {
        base.Initialize();
        m_NavMeshAgent = this.GetComponent<NavMeshAgent>();
        //m_Speed = 3.0f;
        //m_IsMove = false;
    }

    public override void Attack()
    {
        base.Attack();
        Explode();
    }

    public override void Pursue()
    {
        base.Pursue();
        if(m_Detector.Target)
        {
            m_NavMeshAgent.SetDestination(m_Detector.Target.transform.position);
        }
    }

    protected override void SetupStates()
    {
        base.SetupStates();

        Idle idleState = new Idle(this);
        Pursue pursueState = new Pursue(this);
        Engaged engagedState = new Engaged(this);

        m_StateMachine.AddTransition(idleState, pursueState, HasTarget);
        m_StateMachine.AddTransition(pursueState, idleState, LostTarget);
        m_StateMachine.AddTransition(pursueState, engagedState, ReachedTarget);

        m_StateMachine.SetState(idleState);
    }

    private void Awake()
    {
        Initialize();
        SetupStates();
    }

    // Update is called once per frame
    private void Update()
    {
        m_StateMachine.Update();
    }

    private bool HasTarget()
    {
        return m_Detector.Target != null;
    }

    private bool LostTarget()
    {
        return m_Detector.Target == null;
    }

    private bool ReachedTarget()
    {
        if(Vector3.Distance(this.transform.position, m_Detector.Target.transform.position) <= 2.0f)
        {
            return true;
        }

        return false;
    }

    private void Explode()
    {
        Instantiate(m_ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
