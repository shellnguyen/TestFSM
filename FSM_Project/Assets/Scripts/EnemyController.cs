using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private NavMeshAgent m_NavMeshAgent;
    [SerializeField] private Detector m_Detector;
    [SerializeField] private GameObject m_ExplosionPrefab;

    private StateMachine m_StateMachine;

    private void Awake()
    {
        m_Detector.ParentTag = this.tag;
        m_RB = GetComponent<Rigidbody>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_StateMachine = new StateMachine();

        Idle idleState = new Idle();
        Pursue pursueState = new Pursue(m_Detector, m_NavMeshAgent);
        Engaged engagedState = new Engaged(this);

        m_StateMachine.AddTransition(idleState, pursueState, HasTarget);
        m_StateMachine.AddTransition(pursueState, idleState, LostTarget);
        m_StateMachine.AddTransition(pursueState, engagedState, ReachedTarget);

        m_StateMachine.SetState(idleState);
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

    public void Explode()
    {
        Instantiate(m_ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
