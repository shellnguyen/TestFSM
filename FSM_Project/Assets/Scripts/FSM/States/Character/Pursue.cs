using UnityEngine.AI;

public class Pursue : IState
{
    private Detector m_CharacterDetector;
    private NavMeshAgent m_CharacterAgent;

    public Pursue(Detector detector, NavMeshAgent agent)
    {
        m_CharacterDetector = detector;
        m_CharacterAgent = agent;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        if(m_CharacterDetector.Target)
        {
            m_CharacterAgent.SetDestination(m_CharacterDetector.Target.transform.position);
        }
    }
}
