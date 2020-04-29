using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private NavMeshAgent m_NavMeshAgent;
    [SerializeField] private Detector m_Detector;
    [SerializeField] private GameObject m_ExplodeEffect;

    private StateMachine m_StateMachine;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_StateMachine = new StateMachine();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
